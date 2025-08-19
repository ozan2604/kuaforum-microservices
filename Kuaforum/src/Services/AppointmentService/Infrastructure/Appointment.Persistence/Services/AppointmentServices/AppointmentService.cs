using Appointment.Application.Dtos.AppointmentDtos;
using Appointment.Application.Repositories;
using Appointment.Application.Results;
using Appointment.Application.Services.AppointmentServices;
using Appointment.Domain.Entities;
using Appointment.Domain.Enums;
using Appointment.Persistence.Contexts;
using Appointment.Persistence.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

public class AppointmentService : GenericService<Appointment.Domain.Entities.Appointment, AppointmentDto,CreateAppointmentDto,UpdateAppointmentDto>
{
    private readonly AppointmentServiceDbContext _db;
    public AppointmentService(IGenericRepository<Appointment.Domain.Entities.Appointment> repository, IMapper mapper, AppointmentServiceDbContext db) : base(repository, mapper)
    {
        _db = db;
    }

    public async Task<Result<CreateAppointmentResult>> CreateAppointmentAsync(
        CreateAppointmentDto dto,
        CancellationToken ct)
    {
        // Idempotency kontrolü (opsiyonel)
        if (!string.IsNullOrWhiteSpace(dto.CorrelationId))
        {
            var exists = await _db.Appointments
                .AnyAsync(a => a.CorrelationId == dto.CorrelationId, ct);

            if (exists)
                return Result<CreateAppointmentResult>
                    .WarningResult("Bu işlem daha önce yapılmış görünüyor (duplicate correlationId).");
        }

        // Slot çakışma kontrolü
        var overlap = await _db.Appointments.AnyAsync(a =>
            a.StaffId == dto.StaffId &&
            a.Status != AppointmentStatus.Cancelled &&
            a.StartUtc < dto.EndUtc &&
            dto.StartUtc < a.EndUtc, ct);

        if (overlap)
            return Result<CreateAppointmentResult>
                .FailureResult("Seçilen zaman aralığı uygun değil.");

        // ---- Snapshot/Price (örnek; normalde Catalog’tan gelir) ----
        var venueName = "Demo Venue";
        var staffName = "Demo Staff";
        var serviceName = "Haircut";
        var duration = (int)(dto.EndUtc - dto.StartUtc).TotalMinutes;
        var price = 350m;
        var currency = "TRY";
        // ------------------------------------------------------------

        var entity = new Appointment.Domain.Entities.Appointment
        {
            CustomerId = dto.CustomerId,
            VenueId = dto.VenueId,
            StaffId = dto.StaffId,
            ServiceId = dto.ServiceId,
            StartUtc = dto.StartUtc,
            EndUtc = dto.EndUtc,
            Status = AppointmentStatus.Pending,
            Notes = dto.Notes,
            CorrelationId = dto.CorrelationId,
            VenueName = venueName,
            StaffName = staffName,
            ServiceName = serviceName,
            DurationMinutes = duration,
            PriceAtBooking = price,
            Currency = currency
        };

        _db.Appointments.Add(entity);
        await _db.SaveChangesAsync(ct);

        var result = new CreateAppointmentResult
        {
            AppointmentId = entity.Id,
            VenueName = entity.VenueName,
            StaffName = entity.StaffName,
            ServiceName = entity.ServiceName,
            DurationMinutes = entity.DurationMinutes,
            PriceAtBooking = entity.PriceAtBooking,
            Currency = entity.Currency
        };

        return Result<CreateAppointmentResult>.SuccessResult(result, "Randevu oluşturuldu.");
    }
}

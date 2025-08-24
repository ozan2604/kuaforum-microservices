using Appointment.Application.Repositories.AppointmentRepositories;
using Appointment.Application.Results;
using Appointment.Application.Services.CatalogServices;
using Appointment.Application.Services.CurrentUserServices;
using AutoMapper;
using MediatR;

namespace Appointment.Application.Features.Appointments.Commands.CreateAppointment;

public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommandRequest, Result<Guid>>
{
    private readonly IAppointmentRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _current;
    private readonly ICatalogService _catalog;

    public CreateAppointmentCommandHandler(IAppointmentRepository repository, IMapper mapper, ICurrentUserService current, ICatalogService catalog)
    {
        _repository = repository;
        _mapper = mapper;
        _current = current;
        _catalog = catalog;
    }

    public async Task<Result<Guid>> Handle(CreateAppointmentCommandRequest request, CancellationToken cancellationToken)
    {
        var userId = _current.UserId;
        if (userId is null)
            return Result<Guid>.FailureResult("Kullanıcı bulunamadı.");

        var serviceInfo = await _catalog.GetServiceAsync(request.Appointment.ServiceId, cancellationToken);
        var staffInfo = await _catalog.GetStaffAsync(request.Appointment.StaffId, cancellationToken);
        var venueInfo = await _catalog.GetVenueAsync(request.Appointment.VenueId, cancellationToken);

        var entity = _mapper.Map<Appointment.Domain.Entities.Appointment>(request.Appointment);
        entity.CustomerId = userId.Value;

        if (serviceInfo != null)
        {
            entity.ServiceName = serviceInfo.Name;
            entity.DurationMinutes = serviceInfo.Duration;
            entity.PriceAtBooking = serviceInfo.Price;
            entity.EndUtc = entity.StartUtc.AddMinutes(serviceInfo.Duration);
        }

        if (staffInfo != null)
            entity.StaffName = staffInfo.Name;

        if (venueInfo != null)
            entity.VenueName = venueInfo.Name;

        var added = await _repository.AddAsync(entity, cancellationToken);
        if (!added)
            return Result<Guid>.FailureResult("Ekleme başarısız.");

        var saved = await _repository.SaveAsync(cancellationToken);
        return saved > 0
            ? Result<Guid>.SuccessResult(entity.Id, "Başarıyla eklendi.")
            : Result<Guid>.FailureResult("Veritabanına kaydedilemedi.");
    }
}

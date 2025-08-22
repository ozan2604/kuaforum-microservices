using Appointment.Application.Dtos.AppointmentDtos;
using Appointment.Application.Interfaces.Services;
using Appointment.Application.Repositories.AppointmentRepositories;
using Appointment.Application.Results;
using Appointment.Domain.Enums;
using KuaforumContracts.Events.Appointment;
using MassTransit;
using MediatR;

namespace Appointment.Application.Features.Commands.AppointmentCommands.CreateAppointment
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommandRequest, Result<CreateAppointmentResult>>
    {
        private readonly IAppointmentRepository _repository;
        private readonly ICatalogService _catalogService;
        private readonly IPublishEndpoint _publishEndpoint;

        public CreateAppointmentCommandHandler(IAppointmentRepository repository, ICatalogService catalogService, IPublishEndpoint publishEndpoint)
        {
            _repository = repository;
            _catalogService = catalogService;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Result<CreateAppointmentResult>> Handle(CreateAppointmentCommandRequest request, CancellationToken cancellationToken)
        {
            var dto = request.Appointment;

            // Retrieve snapshot information from catalog service
            var catalogInfo = await _catalogService.GetCatalogInfoAsync(dto.VenueId, dto.StaffId, dto.ServiceId, cancellationToken);

            var appointment = new Appointment.Domain.Entities.Appointment
            {
                CustomerId = dto.CustomerId,
                VenueId = dto.VenueId,
                StaffId = dto.StaffId,
                ServiceId = dto.ServiceId,
                StartUtc = dto.StartUtc,
                EndUtc = dto.EndUtc,
                Notes = dto.Notes,
                CorrelationId = dto.CorrelationId,
                Status = AppointmentStatus.Pending,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
                VenueName = catalogInfo.VenueName,
                StaffName = catalogInfo.StaffName,
                ServiceName = catalogInfo.ServiceName,
                DurationMinutes = catalogInfo.DurationMinutes,
                PriceAtBooking = catalogInfo.Price,
                Currency = catalogInfo.Currency
            };

            await _repository.AddAsync(appointment, cancellationToken);
            await _repository.SaveAsync(cancellationToken);

            // Publish appointment created event for asynchronous communication
            await _publishEndpoint.Publish(new AppointmentCreatedEvent
            {
                AppointmentId = appointment.Id,
                CustomerId = appointment.CustomerId,
                VenueId = appointment.VenueId,
                StaffId = appointment.StaffId,
                ServiceId = appointment.ServiceId,
                StartUtc = appointment.StartUtc,
                EndUtc = appointment.EndUtc,
                Notes = appointment.Notes
            }, cancellationToken);

            var resultData = new CreateAppointmentResult
            {
                AppointmentId = appointment.Id,
                VenueName = appointment.VenueName,
                StaffName = appointment.StaffName,
                ServiceName = appointment.ServiceName,
                DurationMinutes = appointment.DurationMinutes,
                PriceAtBooking = appointment.PriceAtBooking,
                Currency = appointment.Currency
            };

            return Result<CreateAppointmentResult>.SuccessResult(resultData, "Appointment created successfully.");
        }
    }
}

using MediatR;
using Appointment.Application.Features.Commands.AppointmentCommands.CreateAppointment;
using Appointment.Application.Repositories.AppointmentRepositories;

public class CreateAppointmentCommandHandler
    : IRequestHandler<CreateAppointmentCommandRequest, CreateAppointmentCommandResponse>
{
    private readonly IAppointmentRepository _repository;

    public CreateAppointmentCommandHandler(IAppointmentRepository repository)
    {
        _repository = repository;
    }

    public  async Task<CreateAppointmentCommandResponse> Handle(CreateAppointmentCommandRequest request, CancellationToken cancellationToken)
    {
        var appointment = new Appointment.Domain.Entities.Appointment
        {
            VenueId = request.VenueId,
            StaffId = request.StaffId,
            ServiceId = request.ServiceId,
            StartUtc = request.StartUtc,
            EndUtc = request.EndUtc,
            Notes = request.Notes,
            CorrelationId = request.CorrelationId,
            Status = Appointment.Domain.Enums.AppointmentStatus.Pending,
            CreateAt = DateTime.UtcNow,
            UpdateAt = DateTime.UtcNow,
            VenueName = request.VenueName,
            StaffName = request.StaffName,
            ServiceName = request.ServiceName,
            DurationMinutes = (int)(request.EndUtc - request.StartUtc).TotalMinutes,
            PriceAtBooking = request.PriceAtBooking,
            Currency = "TRY"
        };


        await _repository.AddAsync(appointment, cancellationToken);
        await _repository.SaveAsync(cancellationToken);

        return new()
        {
            AppointmentId = appointment.Id,
            VenueName = appointment.VenueName,
            StaffName = appointment.StaffName,
            ServiceName = appointment.ServiceName,
            DurationMinutes = appointment.DurationMinutes,
            PriceAtBooking = appointment.PriceAtBooking,
            Currency = appointment.Currency,
            CustomerId = appointment.CustomerId,
            VenueId = appointment.VenueId,
            StaffId = appointment.StaffId,
            ServiceId = appointment.ServiceId,
            StartUtc = appointment.StartUtc,
            EndUtc = appointment.EndUtc,
            Notes = appointment.Notes,
            CorrelationId = appointment.CorrelationId,
            Message = "Appointment created successfully."
        };

    }
}

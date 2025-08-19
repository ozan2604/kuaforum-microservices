using MediatR;
using Appointment.Application.Results;
using Appointment.Application.Dtos.AppointmentDtos;
using Appointment.Application.Services.AppointmentServices;
using Appointment.Application.Features.Commands.AppointmentCommands.CreateAppointment;

public class CreateAppointmentCommandHandler
    : IRequestHandler<CreateAppointmentCommandRequest, CreateAppointmentCommandResponse>
{
    private readonly IAppointmentService _svc;

    public CreateAppointmentCommandHandler(IAppointmentService svc)
    {
        _svc = svc;
    }

    public async Task<CreateAppointmentCommandResponse> Handle(CreateAppointmentCommandRequest request, CancellationToken cancellationToken)
    {
        var dto = new CreateAppointmentDto
        {
           /// CustomerId = _current.UserId, // context
            VenueId = request.VenueId,
            StaffId = request.StaffId,
            ServiceId = request.ServiceId,
            StartUtc = request.StartUtc,
            EndUtc = request.EndUtc,
            Notes = request.Notes,
            CorrelationId = request.CorrelationId
        };

        var result = await _svc.CreateAppointmentAsync(dto, cancellationToken);

        if (!result.Success)
        {
            // iki seçenek:
            // 1) DomainException fırlat → global exception middleware HTTP’ye çevirsin
            // 2) Handler içinde özel mapping yap (aşağıdaki gibi)
           // throw new BusinessRuleException(result.Message); // tercih 1
        }

        // Success — Data’dan response üret
        var data = result.Data;
        return new CreateAppointmentCommandResponse
        {
            AppointmentId = data.AppointmentId,
            VenueName = data.VenueName,
            StaffName = data.StaffName,
            ServiceName = data.ServiceName,
            DurationMinutes = data.DurationMinutes,
            PriceAtBooking = data.PriceAtBooking,
            Currency = data.Currency,
            Message = result.Message
        };
    }
}

using Appointment.Application.Dtos.AppointmentHistoryDtos;
using Appointment.Application.Results;
using MediatR;

namespace Appointment.Application.Features.AppointmentHistories.Commands.UpdateAppointmentHistory;

public class UpdateAppointmentHistoryCommandRequest : IRequest<Result<Guid>>
{
    public required UpdateAppointmentHistoryDto History { get; set; }
}

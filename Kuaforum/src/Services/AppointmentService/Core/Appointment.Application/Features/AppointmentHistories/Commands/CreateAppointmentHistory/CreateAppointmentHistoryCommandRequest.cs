using Appointment.Application.Dtos.AppointmentHistoryDtos;
using Appointment.Application.Results;
using MediatR;

namespace Appointment.Application.Features.AppointmentHistories.Commands.CreateAppointmentHistory;

public class CreateAppointmentHistoryCommandRequest : IRequest<Result<Guid>>
{
    public required CreateAppointmentHistoryDto History { get; set; }
}

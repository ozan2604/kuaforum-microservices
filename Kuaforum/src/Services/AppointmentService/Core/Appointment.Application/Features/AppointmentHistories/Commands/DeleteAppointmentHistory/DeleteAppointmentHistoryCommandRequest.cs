using Appointment.Application.Results;
using MediatR;

namespace Appointment.Application.Features.AppointmentHistories.Commands.DeleteAppointmentHistory;

public class DeleteAppointmentHistoryCommandRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}

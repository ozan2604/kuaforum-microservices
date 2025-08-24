using Appointment.Application.Results;
using MediatR;

namespace Appointment.Application.Features.Appointments.Commands.DeleteAppointment;

public class DeleteAppointmentCommandRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}

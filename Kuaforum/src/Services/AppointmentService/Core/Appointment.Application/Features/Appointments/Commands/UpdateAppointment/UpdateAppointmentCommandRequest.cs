using Appointment.Application.Dtos.AppointmentDtos;
using Appointment.Application.Results;
using MediatR;

namespace Appointment.Application.Features.Appointments.Commands.UpdateAppointment;

public class UpdateAppointmentCommandRequest : IRequest<Result<Guid>>
{
    public required UpdateAppointmentDto Appointment { get; set; }
}

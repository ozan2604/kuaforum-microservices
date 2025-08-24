using Appointment.Application.Dtos.AppointmentDtos;
using Appointment.Application.Results;
using MediatR;

namespace Appointment.Application.Features.Appointments.Commands.CreateAppointment;

public class CreateAppointmentCommandRequest : IRequest<Result<Guid>>
{
    public required CreateAppointmentDto Appointment { get; set; }
}

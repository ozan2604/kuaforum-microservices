using Appointment.Application.Dtos.AppointmentDtos;
using Appointment.Application.Results;
using MediatR;

namespace Appointment.Application.Features.Commands.AppointmentCommands.CreateAppointment
{
    public class CreateAppointmentCommandRequest : IRequest<Result<CreateAppointmentResult>>
    {
        public CreateAppointmentDto Appointment { get; set; } = null!;
    }
}

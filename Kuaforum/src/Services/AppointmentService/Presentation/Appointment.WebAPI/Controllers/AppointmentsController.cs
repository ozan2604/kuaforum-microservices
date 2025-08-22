using Appointment.Application.Dtos.AppointmentDtos;
using Appointment.Application.Features.Commands.AppointmentCommands.CreateAppointment;
using Appointment.Application.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Appointment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AppointmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result<CreateAppointmentResult>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentDto dto)
        {
            var result = await _mediator.Send(new CreateAppointmentCommandRequest { Appointment = dto });
            if (!result.Success)
                return BadRequest(result);

            return StatusCode((int)HttpStatusCode.Created, result);
        }
    }
}

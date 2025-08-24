using Appointment.Application.Dtos.AppointmentHistoryDtos;
using Appointment.Application.Features.AppointmentHistories.Commands.CreateAppointmentHistory;
using Appointment.Application.Features.AppointmentHistories.Commands.DeleteAppointmentHistory;
using Appointment.Application.Features.AppointmentHistories.Commands.UpdateAppointmentHistory;
using Appointment.Application.Features.AppointmentHistories.Queries.GetAppointmentHistories;
using Appointment.Application.Features.AppointmentHistories.Queries.GetAppointmentHistoryById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.WebAPI.Controllers
{
    [Route("appointment/[controller]")]
    [ApiController]
    public class AppointmentHistoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentHistoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetAppointmentHistoryByIdQueryRequest { Id = id });
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAppointmentHistoriesQueryRequest());
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateAppointmentHistoryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateAppointmentHistoryCommandRequest { History = dto });
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateAppointmentHistoryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new UpdateAppointmentHistoryCommandRequest { History = dto });
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteAppointmentHistoryCommandRequest { Id = id });
            return result.Success ? Ok(result) : NotFound(result);
        }
    }
}

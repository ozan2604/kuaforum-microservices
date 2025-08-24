using Catalog.Application.Dtos.WorkScheduleDtos;
using Catalog.Application.Features.WorkSchedules.Commands.CreateWorkSchedule;
using Catalog.Application.Features.WorkSchedules.Commands.DeleteWorkSchedule;
using Catalog.Application.Features.WorkSchedules.Commands.UpdateWorkSchedule;
using Catalog.Application.Features.WorkSchedules.Queries.GetWorkScheduleById;
using Catalog.Application.Features.WorkSchedules.Queries.GetWorkSchedules;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.WebAPI.Controllers
{
    [Route("catalog/[controller]")]
    [ApiController]
    public class WorkSchedulesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkSchedulesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetWorkScheduleByIdQueryRequest { Id = id });
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetWorkSchedulesQueryRequest());
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateWorkScheduleDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateWorkScheduleCommandRequest { WorkSchedule = dto });
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateWorkScheduleDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new UpdateWorkScheduleCommandRequest { WorkSchedule = dto });
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteWorkScheduleCommandRequest { Id = id });
            return result.Success ? Ok(result) : NotFound(result);
        }
    }
}

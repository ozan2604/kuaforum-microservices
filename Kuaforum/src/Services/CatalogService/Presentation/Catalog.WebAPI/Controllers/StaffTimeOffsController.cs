using Catalog.Application.Dtos.StaffTimeOffDtos;
using Catalog.Application.Features.StaffTimeOffs.Commands.CreateStaffTimeOff;
using Catalog.Application.Features.StaffTimeOffs.Commands.DeleteStaffTimeOff;
using Catalog.Application.Features.StaffTimeOffs.Commands.UpdateStaffTimeOff;
using Catalog.Application.Features.StaffTimeOffs.Queries.GetStaffTimeOffById;
using Catalog.Application.Features.StaffTimeOffs.Queries.GetStaffTimeOffs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.WebAPI.Controllers
{
    [Route("catalog/[controller]")]
    [ApiController]
    public class StaffTimeOffsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StaffTimeOffsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetStaffTimeOffByIdQueryRequest { Id = id });
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetStaffTimeOffsQueryRequest());
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateStaffTimeOffDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateStaffTimeOffCommandRequest { TimeOff = dto });
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateStaffTimeOffDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new UpdateStaffTimeOffCommandRequest { TimeOff = dto });
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteStaffTimeOffCommandRequest { Id = id });
            return result.Success ? Ok(result) : NotFound(result);
        }
    }
}

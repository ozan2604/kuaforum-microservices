using Catalog.Application.Dtos.StaffSkillDtos;
using Catalog.Application.Features.StaffSkills.Commands.CreateStaffSkill;
using Catalog.Application.Features.StaffSkills.Commands.DeleteStaffSkill;
using Catalog.Application.Features.StaffSkills.Commands.UpdateStaffSkill;
using Catalog.Application.Features.StaffSkills.Queries.GetStaffSkillById;
using Catalog.Application.Features.StaffSkills.Queries.GetStaffSkills;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.WebAPI.Controllers
{
    [Route("catalog/[controller]")]
    [ApiController]
    public class StaffSkillsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StaffSkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetStaffSkillByIdQueryRequest { Id = id });
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetStaffSkillsQueryRequest());
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateStaffSkillDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateStaffSkillCommandRequest { Skill = dto });
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateStaffSkillDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new UpdateStaffSkillCommandRequest { Skill = dto });
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteStaffSkillCommandRequest { Id = id });
            return result.Success ? Ok(result) : NotFound(result);
        }
    }
}

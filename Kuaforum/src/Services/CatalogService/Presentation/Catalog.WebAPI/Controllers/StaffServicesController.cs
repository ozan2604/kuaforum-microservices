using Catalog.Application.Dtos.StaffServiceDtos;
using Catalog.Application.Features.StaffServices.Commands.CreateStaffService;
using Catalog.Application.Features.StaffServices.Commands.DeleteStaffService;
using Catalog.Application.Features.StaffServices.Commands.UpdateStaffService;
using Catalog.Application.Features.StaffServices.Queries.GetStaffServiceById;
using Catalog.Application.Features.StaffServices.Queries.GetStaffServices;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.WebAPI.Controllers
{
    [Route("catalog/[controller]")]
    [ApiController]
    public class StaffServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StaffServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetStaffServiceByIdQueryRequest { Id = id });
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetStaffServicesQueryRequest());
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateStaffServiceDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateStaffServiceCommandRequest { StaffService = dto });
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateStaffServiceDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new UpdateStaffServiceCommandRequest { StaffService = dto });
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteStaffServiceCommandRequest { Id = id });
            return result.Success ? Ok(result) : NotFound(result);
        }
    }
}

using Catalog.Application.Dtos.HolidayDtos;
using Catalog.Application.Features.Holidays.Commands.CreateHoliday;
using Catalog.Application.Features.Holidays.Commands.DeleteHoliday;
using Catalog.Application.Features.Holidays.Commands.UpdateHoliday;
using Catalog.Application.Features.Holidays.Queries.GetHolidayById;
using Catalog.Application.Features.Holidays.Queries.GetHolidays;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.WebAPI.Controllers
{
    [Route("catalog/[controller]")]
    [ApiController]
    public class HolidaysController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HolidaysController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetHolidayByIdQueryRequest { Id = id });
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetHolidaysQueryRequest());
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateHolidayDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateHolidayCommandRequest { Holiday = dto });
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateHolidayDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new UpdateHolidayCommandRequest { Holiday = dto });
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteHolidayCommandRequest { Id = id });
            return result.Success ? Ok(result) : NotFound(result);
        }
    }
}

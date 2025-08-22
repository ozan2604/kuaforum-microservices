using Catalog.Application.Dtos.VenueDtos;
using Catalog.Application.Features.Venues.Commands.CreateVenue;
using Catalog.Application.Features.Venues.Commands.DeleteVenue;
using Catalog.Application.Features.Venues.Commands.UpdateVenue;
using Catalog.Application.Features.Venues.Queries.GetVenueById;
using Catalog.Application.Features.Venues.Queries.GetVenues;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenuesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VenuesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetVenueByIdQueryRequest { Id = id });
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetVenuesQueryRequest());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VenueDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateVenueCommandRequest { Venue = dto });
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] VenueDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new UpdateVenueCommandRequest { Venue = dto });
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteVenueCommandRequest { Id = id });
            return result.Success ? Ok(result) : NotFound(result);
        }
    }
}

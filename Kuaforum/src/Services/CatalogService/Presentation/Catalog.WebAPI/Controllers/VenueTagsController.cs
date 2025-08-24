using Catalog.Application.Dtos.VenueTagDtos;
using Catalog.Application.Features.VenueTags.Commands.CreateVenueTag;
using Catalog.Application.Features.VenueTags.Commands.DeleteVenueTag;
using Catalog.Application.Features.VenueTags.Queries.GetVenueTagById;
using Catalog.Application.Features.VenueTags.Queries.GetVenueTags;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.WebAPI.Controllers
{
    [Route("catalog/[controller]")]
    [ApiController]
    public class VenueTagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VenueTagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{venueId}/{tagId}")]
        public async Task<IActionResult> GetById(Guid venueId, Guid tagId)
        {
            var result = await _mediator.Send(new GetVenueTagByIdQueryRequest { VenueId = venueId, TagId = tagId });
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetVenueTagsQueryRequest());
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateVenueTagDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateVenueTagCommandRequest { VenueTag = dto });
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{venueId}/{tagId}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid venueId, Guid tagId)
        {
            var result = await _mediator.Send(new DeleteVenueTagCommandRequest { VenueId = venueId, TagId = tagId });
            return result.Success ? Ok(result) : NotFound(result);
        }
    }
}

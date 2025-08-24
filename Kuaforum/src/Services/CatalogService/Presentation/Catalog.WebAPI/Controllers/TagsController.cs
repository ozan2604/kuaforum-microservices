using Catalog.Application.Dtos.TagDtos;
using Catalog.Application.Features.Tags.Commands.CreateTag;
using Catalog.Application.Features.Tags.Commands.DeleteTag;
using Catalog.Application.Features.Tags.Commands.UpdateTag;
using Catalog.Application.Features.Tags.Queries.GetTagById;
using Catalog.Application.Features.Tags.Queries.GetTags;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.WebAPI.Controllers
{
    [Route("catalog/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetTagByIdQueryRequest { Id = id });
            return result.Success ? Ok(result) : NotFound(result);
            }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetTagsQueryRequest());
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateTagDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateTagCommandRequest { Tag = dto });
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateTagDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new UpdateTagCommandRequest { Tag = dto });
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteTagCommandRequest { Id = id });
            return result.Success ? Ok(result) : NotFound(result);
        }
    }
}

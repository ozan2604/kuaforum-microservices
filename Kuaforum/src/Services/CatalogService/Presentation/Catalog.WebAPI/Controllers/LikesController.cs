using Catalog.Application.Dtos.LikeDtos;
using Catalog.Application.Features.Likes.Commands.CreateLike;
using Catalog.Application.Features.Likes.Commands.DeleteLike;
using Catalog.Application.Features.Likes.Commands.UpdateLike;
using Catalog.Application.Features.Likes.Queries.GetLikeById;
using Catalog.Application.Features.Likes.Queries.GetLikes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.WebAPI.Controllers
{
    [Route("catalog/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LikesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetLikeByIdQueryRequest { Id = id });
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetLikesQueryRequest());
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateLikeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateLikeCommandRequest { Like = dto });
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateLikeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new UpdateLikeCommandRequest { Like = dto });
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteLikeCommandRequest { Id = id });
            return result.Success ? Ok(result) : NotFound(result);
        }
    }
}

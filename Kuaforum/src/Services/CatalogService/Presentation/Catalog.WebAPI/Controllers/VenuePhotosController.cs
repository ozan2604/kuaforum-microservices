using Catalog.Application.Dtos.VenuePhotoDtos;
using Catalog.Application.Features.VenuePhotos.Commands.CreateVenuePhoto;
using Catalog.Application.Features.VenuePhotos.Commands.DeleteVenuePhoto;
using Catalog.Application.Features.VenuePhotos.Commands.UpdateVenuePhoto;
using Catalog.Application.Features.VenuePhotos.Queries.GetVenuePhotoById;
using Catalog.Application.Features.VenuePhotos.Queries.GetVenuePhotos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.WebAPI.Controllers
{
    [Route("catalog/[controller]")]
    [ApiController]
    public class VenuePhotosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VenuePhotosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetVenuePhotoByIdQueryRequest { Id = id });
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetVenuePhotosQueryRequest());
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateVenuePhotoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateVenuePhotoCommandRequest { Photo = dto });
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateVenuePhotoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new UpdateVenuePhotoCommandRequest { Photo = dto });
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteVenuePhotoCommandRequest { Id = id });
            return result.Success ? Ok(result) : NotFound(result);
        }
    }
}

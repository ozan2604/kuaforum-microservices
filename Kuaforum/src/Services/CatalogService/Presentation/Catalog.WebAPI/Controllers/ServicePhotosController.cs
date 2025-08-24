using Catalog.Application.Dtos.ServicePhotoDtos;
using Catalog.Application.Features.ServicePhotos.Commands.CreateServicePhoto;
using Catalog.Application.Features.ServicePhotos.Commands.DeleteServicePhoto;
using Catalog.Application.Features.ServicePhotos.Commands.UpdateServicePhoto;
using Catalog.Application.Features.ServicePhotos.Queries.GetServicePhotoById;
using Catalog.Application.Features.ServicePhotos.Queries.GetServicePhotos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.WebAPI.Controllers
{
    [Route("catalog/[controller]")]
    [ApiController]
    public class ServicePhotosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicePhotosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetServicePhotoByIdQueryRequest { Id = id });
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetServicePhotosQueryRequest());
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateServicePhotoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateServicePhotoCommandRequest { Photo = dto });
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateServicePhotoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new UpdateServicePhotoCommandRequest { Photo = dto });
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteServicePhotoCommandRequest { Id = id });
            return result.Success ? Ok(result) : NotFound(result);
        }
    }
}

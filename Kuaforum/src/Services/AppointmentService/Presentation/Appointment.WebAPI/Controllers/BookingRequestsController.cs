using Appointment.Application.Dtos.BookingRequestDtos;
using Appointment.Application.Features.BookingRequests.Commands.CreateBookingRequest;
using Appointment.Application.Features.BookingRequests.Commands.DeleteBookingRequest;
using Appointment.Application.Features.BookingRequests.Commands.UpdateBookingRequest;
using Appointment.Application.Features.BookingRequests.Queries.GetBookingRequestById;
using Appointment.Application.Features.BookingRequests.Queries.GetBookingRequests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.WebAPI.Controllers
{
    [Route("appointment/[controller]")]
    [ApiController]
    public class BookingRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetBookingRequestByIdQueryRequest { Id = id });
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetBookingRequestsQueryRequest());
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateBookingRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateBookingRequestCommandRequest { BookingRequest = dto });
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateBookingRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new UpdateBookingRequestCommandRequest { BookingRequest = dto });
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteBookingRequestCommandRequest { Id = id });
            return result.Success ? Ok(result) : NotFound(result);
        }
    }
}

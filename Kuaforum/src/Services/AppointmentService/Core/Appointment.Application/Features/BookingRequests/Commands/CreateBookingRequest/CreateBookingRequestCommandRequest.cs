using Appointment.Application.Dtos.BookingRequestDtos;
using Appointment.Application.Results;
using MediatR;

namespace Appointment.Application.Features.BookingRequests.Commands.CreateBookingRequest;

public class CreateBookingRequestCommandRequest : IRequest<Result<Guid>>
{
    public required CreateBookingRequestDto BookingRequest { get; set; }
}

using Appointment.Application.Dtos.BookingRequestDtos;
using Appointment.Application.Results;
using MediatR;

namespace Appointment.Application.Features.BookingRequests.Commands.UpdateBookingRequest;

public class UpdateBookingRequestCommandRequest : IRequest<Result<Guid>>
{
    public required UpdateBookingRequestDto BookingRequest { get; set; }
}

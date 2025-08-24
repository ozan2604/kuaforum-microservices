using Appointment.Application.Results;
using MediatR;

namespace Appointment.Application.Features.BookingRequests.Commands.DeleteBookingRequest;

public class DeleteBookingRequestCommandRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}

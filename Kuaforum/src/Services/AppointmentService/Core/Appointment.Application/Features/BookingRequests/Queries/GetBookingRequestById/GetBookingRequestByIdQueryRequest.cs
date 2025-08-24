using Appointment.Application.Dtos.BookingRequestDtos;
using Appointment.Application.Results;
using MediatR;

namespace Appointment.Application.Features.BookingRequests.Queries.GetBookingRequestById;

public class GetBookingRequestByIdQueryRequest : IRequest<Result<ResultBookingRequestDto>>
{
    public Guid Id { get; set; }
}

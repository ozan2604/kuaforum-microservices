using Appointment.Application.Dtos.BookingRequestDtos;
using Appointment.Application.Results;
using MediatR;

namespace Appointment.Application.Features.BookingRequests.Queries.GetBookingRequests;

public class GetBookingRequestsQueryRequest : IRequest<Result<List<ResultBookingRequestDto>>>
{
}

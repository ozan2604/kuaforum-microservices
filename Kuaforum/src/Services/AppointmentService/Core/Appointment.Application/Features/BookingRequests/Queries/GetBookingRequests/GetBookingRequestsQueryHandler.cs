using Appointment.Application.Dtos.BookingRequestDtos;
using Appointment.Application.Repositories.BookingRequestRepositories;
using Appointment.Application.Results;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Application.Features.BookingRequests.Queries.GetBookingRequests;

public class GetBookingRequestsQueryHandler : IRequestHandler<GetBookingRequestsQueryRequest, Result<List<ResultBookingRequestDto>>>
{
    private readonly IBookingRequestRepository _repository;
    private readonly IMapper _mapper;

    public GetBookingRequestsQueryHandler(IBookingRequestRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<ResultBookingRequestDto>>> Handle(GetBookingRequestsQueryRequest request, CancellationToken cancellationToken)
    {
        var requests = await _repository.GetAll(false).ToListAsync(cancellationToken);
        var dtoList = _mapper.Map<List<ResultBookingRequestDto>>(requests);
        return Result<List<ResultBookingRequestDto>>.SuccessResult(dtoList);
    }
}

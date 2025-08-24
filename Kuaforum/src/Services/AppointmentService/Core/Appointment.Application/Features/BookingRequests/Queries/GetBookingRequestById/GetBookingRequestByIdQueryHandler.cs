using Appointment.Application.Dtos.BookingRequestDtos;
using Appointment.Application.Repositories.BookingRequestRepositories;
using Appointment.Application.Results;
using AutoMapper;
using MediatR;

namespace Appointment.Application.Features.BookingRequests.Queries.GetBookingRequestById;

public class GetBookingRequestByIdQueryHandler : IRequestHandler<GetBookingRequestByIdQueryRequest, Result<ResultBookingRequestDto>>
{
    private readonly IBookingRequestRepository _repository;
    private readonly IMapper _mapper;

    public GetBookingRequestByIdQueryHandler(IBookingRequestRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<ResultBookingRequestDto>> Handle(GetBookingRequestByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var br = await _repository.GetByIdAsync(request.Id);
        if (br == null)
            return Result<ResultBookingRequestDto>.FailureResult("Kayıt bulunamadı.");
        var dto = _mapper.Map<ResultBookingRequestDto>(br);
        return Result<ResultBookingRequestDto>.SuccessResult(dto);
    }
}

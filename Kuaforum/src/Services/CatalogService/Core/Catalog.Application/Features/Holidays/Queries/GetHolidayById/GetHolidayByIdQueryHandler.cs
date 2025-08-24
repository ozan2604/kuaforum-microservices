using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.HolidayDtos;
using Catalog.Application.Repositories.HolidayRepository;
using MediatR;

namespace Catalog.Application.Features.Holidays.Queries.GetHolidayById;

public class GetHolidayByIdQueryHandler : IRequestHandler<GetHolidayByIdQueryRequest, Result<ResultHolidayDto>>
{
    private readonly IHolidayRepository _repository;
    private readonly IMapper _mapper;

    public GetHolidayByIdQueryHandler(IHolidayRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<ResultHolidayDto>> Handle(GetHolidayByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var holiday = await _repository.GetByIdAsync(request.Id, false);
        if (holiday == null)
            return Result<ResultHolidayDto>.FailureResult("Kayıt bulunamadı.");

        var dto = _mapper.Map<ResultHolidayDto>(holiday);
        return Result<ResultHolidayDto>.SuccessResult(dto);
    }
}

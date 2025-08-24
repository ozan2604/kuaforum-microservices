using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.HolidayDtos;
using Catalog.Application.Repositories.HolidayRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Application.Features.Holidays.Queries.GetHolidays;

public class GetHolidaysQueryHandler : IRequestHandler<GetHolidaysQueryRequest, Result<List<ResultHolidayDto>>>
{
    private readonly IHolidayRepository _repository;
    private readonly IMapper _mapper;

    public GetHolidaysQueryHandler(IHolidayRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<ResultHolidayDto>>> Handle(GetHolidaysQueryRequest request, CancellationToken cancellationToken)
    {
        var holidays = await _repository.GetAll(false).ToListAsync(cancellationToken);
        var dtoList = _mapper.Map<List<ResultHolidayDto>>(holidays);
        return Result<List<ResultHolidayDto>>.SuccessResult(dtoList);
    }
}

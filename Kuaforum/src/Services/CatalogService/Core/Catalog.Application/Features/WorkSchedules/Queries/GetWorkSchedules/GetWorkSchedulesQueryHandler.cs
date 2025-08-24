using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.WorkScheduleDtos;
using Catalog.Application.Repositories.WorkScheduleRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Application.Features.WorkSchedules.Queries.GetWorkSchedules;

public class GetWorkSchedulesQueryHandler : IRequestHandler<GetWorkSchedulesQueryRequest, Result<List<ResultWorkScheduleDto>>>
{
    private readonly IWorkScheduleRepository _repository;
    private readonly IMapper _mapper;

    public GetWorkSchedulesQueryHandler(IWorkScheduleRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<ResultWorkScheduleDto>>> Handle(GetWorkSchedulesQueryRequest request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAll(false).ToListAsync(cancellationToken);
        var dtoList = _mapper.Map<List<ResultWorkScheduleDto>>(entities);
        return Result<List<ResultWorkScheduleDto>>.SuccessResult(dtoList);
    }
}

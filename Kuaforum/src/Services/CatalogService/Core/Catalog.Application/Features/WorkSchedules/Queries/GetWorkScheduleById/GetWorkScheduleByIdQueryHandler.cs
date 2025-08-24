using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.WorkScheduleDtos;
using Catalog.Application.Repositories.WorkScheduleRepository;
using MediatR;

namespace Catalog.Application.Features.WorkSchedules.Queries.GetWorkScheduleById;

public class GetWorkScheduleByIdQueryHandler : IRequestHandler<GetWorkScheduleByIdQueryRequest, Result<ResultWorkScheduleDto>>
{
    private readonly IWorkScheduleRepository _repository;
    private readonly IMapper _mapper;

    public GetWorkScheduleByIdQueryHandler(IWorkScheduleRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<ResultWorkScheduleDto>> Handle(GetWorkScheduleByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, false);
        if (entity == null)
            return Result<ResultWorkScheduleDto>.FailureResult("Kayıt bulunamadı.");

        var dto = _mapper.Map<ResultWorkScheduleDto>(entity);
        return Result<ResultWorkScheduleDto>.SuccessResult(dto);
    }
}

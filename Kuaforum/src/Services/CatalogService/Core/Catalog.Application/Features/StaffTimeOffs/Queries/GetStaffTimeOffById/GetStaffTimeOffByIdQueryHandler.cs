using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.StaffTimeOffDtos;
using Catalog.Application.Repositories.StaffTimeOffRepository;
using MediatR;

namespace Catalog.Application.Features.StaffTimeOffs.Queries.GetStaffTimeOffById;

public class GetStaffTimeOffByIdQueryHandler : IRequestHandler<GetStaffTimeOffByIdQueryRequest, Result<ResultStaffTimeOffDto>>
{
    private readonly IStaffTimeOffRepository _repository;
    private readonly IMapper _mapper;

    public GetStaffTimeOffByIdQueryHandler(IStaffTimeOffRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<ResultStaffTimeOffDto>> Handle(GetStaffTimeOffByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, false);
        if (entity == null)
            return Result<ResultStaffTimeOffDto>.FailureResult("Kayıt bulunamadı.");

        var dto = _mapper.Map<ResultStaffTimeOffDto>(entity);
        return Result<ResultStaffTimeOffDto>.SuccessResult(dto);
    }
}

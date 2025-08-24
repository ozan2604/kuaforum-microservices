using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.StaffTimeOffDtos;
using Catalog.Application.Repositories.StaffTimeOffRepository;
using MediatR;

namespace Catalog.Application.Features.StaffTimeOffs.Queries.GetStaffTimeOffs;

public class GetStaffTimeOffsQueryHandler : IRequestHandler<GetStaffTimeOffsQueryRequest, Result<List<ResultStaffTimeOffDto>>>
{
    private readonly IStaffTimeOffRepository _repository;
    private readonly IMapper _mapper;

    public GetStaffTimeOffsQueryHandler(IStaffTimeOffRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<ResultStaffTimeOffDto>>> Handle(GetStaffTimeOffsQueryRequest request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(false);
        var dtos = _mapper.Map<List<ResultStaffTimeOffDto>>(entities);
        return Result<List<ResultStaffTimeOffDto>>.SuccessResult(dtos);
    }
}

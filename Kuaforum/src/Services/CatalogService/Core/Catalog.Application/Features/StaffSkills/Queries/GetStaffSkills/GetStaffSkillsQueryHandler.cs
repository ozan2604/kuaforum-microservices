using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.StaffSkillDtos;
using Catalog.Application.Repositories.StaffSkillRepository;
using MediatR;

namespace Catalog.Application.Features.StaffSkills.Queries.GetStaffSkills;

public class GetStaffSkillsQueryHandler : IRequestHandler<GetStaffSkillsQueryRequest, Result<List<ResultStaffSkillDto>>>
{
    private readonly IStaffSkillRepository _repository;
    private readonly IMapper _mapper;

    public GetStaffSkillsQueryHandler(IStaffSkillRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<ResultStaffSkillDto>>> Handle(GetStaffSkillsQueryRequest request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(false);
        var dtos = _mapper.Map<List<ResultStaffSkillDto>>(entities);
        return Result<List<ResultStaffSkillDto>>.SuccessResult(dtos);
    }
}

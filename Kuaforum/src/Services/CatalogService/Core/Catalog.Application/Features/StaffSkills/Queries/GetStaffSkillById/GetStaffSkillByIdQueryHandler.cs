using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.StaffSkillDtos;
using Catalog.Application.Repositories.StaffSkillRepository;
using MediatR;

namespace Catalog.Application.Features.StaffSkills.Queries.GetStaffSkillById;

public class GetStaffSkillByIdQueryHandler : IRequestHandler<GetStaffSkillByIdQueryRequest, Result<ResultStaffSkillDto>>
{
    private readonly IStaffSkillRepository _repository;
    private readonly IMapper _mapper;

    public GetStaffSkillByIdQueryHandler(IStaffSkillRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<ResultStaffSkillDto>> Handle(GetStaffSkillByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, false);
        if (entity == null)
            return Result<ResultStaffSkillDto>.FailureResult("Kayıt bulunamadı.");

        var dto = _mapper.Map<ResultStaffSkillDto>(entity);
        return Result<ResultStaffSkillDto>.SuccessResult(dto);
    }
}

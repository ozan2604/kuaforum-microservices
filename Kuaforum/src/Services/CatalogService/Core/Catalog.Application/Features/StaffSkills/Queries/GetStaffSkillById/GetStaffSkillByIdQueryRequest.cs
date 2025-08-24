using Application.Results;
using Catalog.Application.Dtos.StaffSkillDtos;
using MediatR;

namespace Catalog.Application.Features.StaffSkills.Queries.GetStaffSkillById;

public class GetStaffSkillByIdQueryRequest : IRequest<Result<ResultStaffSkillDto>>
{
    public Guid Id { get; set; }
}

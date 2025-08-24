using Application.Results;
using Catalog.Application.Dtos.StaffSkillDtos;
using MediatR;

namespace Catalog.Application.Features.StaffSkills.Queries.GetStaffSkills;

public class GetStaffSkillsQueryRequest : IRequest<Result<List<ResultStaffSkillDto>>>
{
}

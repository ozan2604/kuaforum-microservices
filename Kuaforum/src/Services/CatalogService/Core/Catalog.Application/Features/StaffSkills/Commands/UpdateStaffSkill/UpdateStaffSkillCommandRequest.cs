using Application.Results;
using Catalog.Application.Dtos.StaffSkillDtos;
using MediatR;

namespace Catalog.Application.Features.StaffSkills.Commands.UpdateStaffSkill;

public class UpdateStaffSkillCommandRequest : IRequest<Result>
{
    public required UpdateStaffSkillDto Skill { get; set; }
}

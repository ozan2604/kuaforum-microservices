using Application.Results;
using Catalog.Application.Dtos.StaffSkillDtos;
using MediatR;

namespace Catalog.Application.Features.StaffSkills.Commands.CreateStaffSkill;

public class CreateStaffSkillCommandRequest : IRequest<Result<Guid>>
{
    public required CreateStaffSkillDto Skill { get; set; }
}

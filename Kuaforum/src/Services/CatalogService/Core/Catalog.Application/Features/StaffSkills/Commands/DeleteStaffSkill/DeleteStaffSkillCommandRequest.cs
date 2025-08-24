using Application.Results;
using MediatR;

namespace Catalog.Application.Features.StaffSkills.Commands.DeleteStaffSkill;

public class DeleteStaffSkillCommandRequest : IRequest<Result>
{
    public Guid Id { get; set; }
}

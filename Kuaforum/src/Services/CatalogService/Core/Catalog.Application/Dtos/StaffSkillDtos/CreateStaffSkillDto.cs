namespace Catalog.Application.Dtos.StaffSkillDtos;

public class CreateStaffSkillDto
{
    public Guid StaffId { get; set; }
    public string SkillName { get; set; } = string.Empty;
}

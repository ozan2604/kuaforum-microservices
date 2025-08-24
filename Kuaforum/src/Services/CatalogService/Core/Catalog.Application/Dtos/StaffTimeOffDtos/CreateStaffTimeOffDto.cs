namespace Catalog.Application.Dtos.StaffTimeOffDtos;

public class CreateStaffTimeOffDto
{
    public Guid StaffId { get; set; }
    public DateTime StartUtc { get; set; }
    public DateTime EndUtc { get; set; }
    public string? Reason { get; set; }
}

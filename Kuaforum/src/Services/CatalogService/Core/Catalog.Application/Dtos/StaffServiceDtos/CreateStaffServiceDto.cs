namespace Catalog.Application.Dtos.StaffServiceDtos;

public class CreateStaffServiceDto
{
    public Guid StaffId { get; set; }
    public Guid ServiceId { get; set; }
    public int? DurationMinutesOverride { get; set; }
    public decimal? PriceOverride { get; set; }
}

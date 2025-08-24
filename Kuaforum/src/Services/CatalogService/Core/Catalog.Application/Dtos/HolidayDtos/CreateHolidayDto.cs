using System;

namespace Catalog.Application.Dtos.HolidayDtos;

public class CreateHolidayDto
{
    public Guid? VenueId { get; set; }
    public Guid? StaffId { get; set; }
    public DateOnly Date { get; set; }
    public string? Reason { get; set; }
}

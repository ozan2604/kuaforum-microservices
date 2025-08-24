namespace Catalog.Application.Dtos.StaffDtos;

public class CreateStaffDto
{
    public Guid VenueId { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public string? PhoneNum { get; set; }
    public int? BufferMinutes { get; set; }
    public int MaxConcurrentAppointments { get; set; } = 1;
    public string? Bio { get; set; }
    public string? AvatarUrl { get; set; }
}

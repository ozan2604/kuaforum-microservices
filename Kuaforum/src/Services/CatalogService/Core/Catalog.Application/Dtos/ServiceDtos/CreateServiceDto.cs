namespace Catalog.Application.Dtos.ServiceDtos;

public class CreateServiceDto
{
    public Guid VenueId { get; set; }
    public required string Name { get; set; }
    public string? Category { get; set; }
    public int DurationMinutes { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; } = "TRY";
    public string? Gender { get; set; }
}

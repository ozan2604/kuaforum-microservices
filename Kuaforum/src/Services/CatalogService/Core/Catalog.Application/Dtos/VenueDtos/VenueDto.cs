using Catalog.Domain.Enums;

namespace Catalog.Application.Dtos.VenueDtos;

public class VenueDto
{
    public Guid Id { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? CreatedAt { get; set; }
    public Guid? CreateUserId { get; set; } = default!;
    public string CreateUserName { get; set; } = string.Empty;
    public string? UpdateUserName { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid? UpdateUserId { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
    public Guid? DeleteUserId { get; set; }
    public required string Name { get; set; }
    public VenueType Type { get; set; }
    public string? Description { get; set; }

    public required string Phone { get; set; }
    public required string Email { get; set; }
    public string? Website { get; set; }
    public required string FullAddress { get; set; }
    public required string City { get; set; }
    public required string Town { get; set; }
    public required string Country { get; set; }
    public string? PostalCode { get; set; }
    public decimal AvgRating { get; set; } = 0m;
    public int RatingsCount { get; set; } = 0;
}

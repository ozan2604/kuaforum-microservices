using System;

namespace Catalog.Application.Dtos.VenuePhotoDtos;

public class VenuePhotoDto
{
    public Guid Id { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? CreatedAt { get; set; }
    public Guid? CreateUserId { get; set; }
    public string CreateUserName { get; set; } = string.Empty;
    public string? UpdateUserName { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid? UpdateUserId { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
    public Guid? DeleteUserId { get; set; }

    public Guid VenueId { get; set; }
    public required string Url { get; set; }
    public bool IsCover { get; set; }
    public int SortOrder { get; set; }
}

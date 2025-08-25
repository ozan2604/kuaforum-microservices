using System;

namespace Catalog.Application.Dtos.ImageDtos;

public class ResultImageDto
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

    public required string Url { get; set; }
    public bool IsCover { get; set; } = false;
    public int SortOrder { get; set; } = 0;
    public Guid VenueId { get; set; }
    public Guid ServiceId { get; set; }
}

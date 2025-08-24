using System;

namespace Catalog.Application.Dtos.StaffServiceDtos;

public class StaffServiceDto
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

    public Guid StaffId { get; set; }
    public Guid ServiceId { get; set; }
    public int? DurationMinutesOverride { get; set; }
    public decimal? PriceOverride { get; set; }
}

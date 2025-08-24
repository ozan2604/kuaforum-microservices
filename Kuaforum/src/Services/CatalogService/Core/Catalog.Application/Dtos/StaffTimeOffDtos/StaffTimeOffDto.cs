using System;

namespace Catalog.Application.Dtos.StaffTimeOffDtos;

public class StaffTimeOffDto
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
    public DateTime StartUtc { get; set; }
    public DateTime EndUtc { get; set; }
    public string? Reason { get; set; }
}

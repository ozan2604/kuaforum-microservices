using System;

namespace Catalog.Application.Dtos.StaffDtos;

public class ResultStaffDto
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
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public string? PhoneNum { get; set; }
    public int? BufferMinutes { get; set; }
    public int MaxConcurrentAppointments { get; set; }
    public string? Bio { get; set; }
    public string? AvatarUrl { get; set; }
    public decimal RatingAvg { get; set; }
    public int RatingCount { get; set; }

    public int ServicesCount { get; set; }
}

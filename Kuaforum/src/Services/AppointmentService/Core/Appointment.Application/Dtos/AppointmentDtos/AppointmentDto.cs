using Appointment.Domain.Enums;

namespace Appointment.Application.Dtos.AppointmentDtos;

public class AppointmentDto
{
    public Guid Id { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTimeOffset CreateAt { get; set; }
    public Guid? CreateUserId { get; set; }
    public string CreateUserName { get; set; } = string.Empty;
    public string? UpdateUserName { get; set; }
    public DateTimeOffset? UpdateAt { get; set; }
    public Guid? UpdateUserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeleteAt { get; set; }
    public Guid? DeleteUserId { get; set; }

    public Guid CustomerId { get; set; }
    public Guid VenueId { get; set; }
    public Guid StaffId { get; set; }
    public Guid ServiceId { get; set; }
    public DateTime StartUtc { get; set; }
    public DateTime EndUtc { get; set; }
    public AppointmentStatus Status { get; set; }
    public string? Notes { get; set; }
    public string? CorrelationId { get; set; }
    public byte[]? RowVersion { get; set; }
    public string VenueName { get; set; } = string.Empty;
    public string StaffName { get; set; } = string.Empty;
    public string ServiceName { get; set; } = string.Empty;
    public int DurationMinutes { get; set; }
    public decimal PriceAtBooking { get; set; }
    public string Currency { get; set; } = "TRY";
}

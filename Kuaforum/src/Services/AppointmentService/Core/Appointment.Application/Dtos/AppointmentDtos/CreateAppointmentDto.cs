using Appointment.Domain.Enums;

namespace Appointment.Application.Dtos.AppointmentDtos;

public class CreateAppointmentDto
{
    
    public Guid VenueId { get; set; }
    public Guid StaffId { get; set; }
    public Guid ServiceId { get; set; }
    public DateTime StartUtc { get; set; }
    public DateTime EndUtc { get; set; }
    public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;
    public string? Notes { get; set; }
    public string? CorrelationId { get; set; }
    public string VenueName { get; set; } = string.Empty;
    public string StaffName { get; set; } = string.Empty;
    public string ServiceName { get; set; } = string.Empty;
    public int DurationMinutes { get; set; }
    public decimal PriceAtBooking { get; set; }
    public string Currency { get; set; } = "TRY";
}

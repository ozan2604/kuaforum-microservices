using Appointment.Domain.Enums;

namespace Appointment.Application.Dtos.AppointmentDtos;

public class UpdateAppointmentDto
{
    public Guid Id { get; set; }
    public DateTime StartUtc { get; set; }
    public DateTime EndUtc { get; set; }
    public AppointmentStatus Status { get; set; }
    public string? Notes { get; set; }
    public int DurationMinutes { get; set; }
    public decimal PriceAtBooking { get; set; }
    public string Currency { get; set; } = "TRY";
}

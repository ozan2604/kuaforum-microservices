namespace Appointment.Application.Dtos.AppointmentHistoryDtos;

public class UpdateAppointmentHistoryDto
{
    public Guid Id { get; set; }
    public DateTime AtUtc { get; set; }
    public string Action { get; set; } = string.Empty;
    public string? PerformedBy { get; set; }
    public string? Description { get; set; }
}

namespace Appointment.Application.Dtos.AppointmentHistoryDtos;

public class CreateAppointmentHistoryDto
{
    public Guid AppointmentId { get; set; }
    public DateTime AtUtc { get; set; }
    public string Action { get; set; } = string.Empty;
    public string? PerformedBy { get; set; }
    public string? Description { get; set; }
}

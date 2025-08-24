namespace Appointment.Application.Dtos.AppointmentHistoryDtos;

public class ResultAppointmentHistoryDto
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

    public Guid AppointmentId { get; set; }
    public DateTime AtUtc { get; set; }
    public string Action { get; set; } = string.Empty;
    public string? PerformedBy { get; set; }
    public string? Description { get; set; }
}

using System;

namespace Catalog.Application.Dtos.WorkScheduleDtos;

public class UpdateWorkScheduleDto
{
    public Guid Id { get; set; }
    public Guid StaffId { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public TimeOnly? BreakStart { get; set; }
    public TimeOnly? BreakEnd { get; set; }
}

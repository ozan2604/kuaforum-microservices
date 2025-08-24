namespace Appointment.Application.Dtos.BookingRequestDtos;

public class UpdateBookingRequestDto
{
    public Guid Id { get; set; }
    public DateTime ConsumedAtUtc { get; set; }
}

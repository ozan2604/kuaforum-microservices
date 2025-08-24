namespace Appointment.Application.Dtos.BookingRequestDtos;

public class CreateBookingRequestDto
{
    public Guid CustomerId { get; set; }
    public string IdempotencyKey { get; set; } = string.Empty;
}

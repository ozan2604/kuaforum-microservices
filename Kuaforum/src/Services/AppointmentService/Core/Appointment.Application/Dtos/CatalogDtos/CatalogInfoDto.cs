namespace Appointment.Application.Dtos.CatalogDtos
{
    public class CatalogInfoDto
    {
        public string VenueName { get; set; } = string.Empty;
        public string StaffName { get; set; } = string.Empty;
        public string ServiceName { get; set; } = string.Empty;
        public int DurationMinutes { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; } = "TRY";
    }
}

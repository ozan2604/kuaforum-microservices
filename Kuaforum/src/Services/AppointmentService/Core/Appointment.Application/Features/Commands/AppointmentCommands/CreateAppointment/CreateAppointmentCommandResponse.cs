using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.Features.Commands.AppointmentCommands.CreateAppointment
{
    public class CreateAppointmentCommandResponse
    {
        public Guid AppointmentId { get; set; }
        public string VenueName { get; set; }
        public string StaffName { get; set; }
        public string ServiceName { get; set; }
        public int DurationMinutes { get; set; }
        public decimal PriceAtBooking { get; set; }
        public string Currency { get; set; }
        public string Message { get; set; }
        public Guid CustomerId { get; set; }
        public Guid VenueId { get; set; }
        public Guid StaffId { get; set; }
        public Guid ServiceId { get; set; }
        public DateTime StartUtc { get; set; }
        public DateTime EndUtc { get; set; }
        public string Notes { get; set; }
        public string CorrelationId { get; set; }
    }
}

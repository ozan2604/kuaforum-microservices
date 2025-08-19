using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.Dtos.AppointmentDtos
{
    public class CreateAppointmentResult
    {
        public Guid AppointmentId { get; set; }
        public string VenueName { get; set; }
        public string StaffName { get; set; }
        public string ServiceName { get; set; }
        public int DurationMinutes { get; set; }
        public decimal PriceAtBooking { get; set; }
        public string Currency { get; set; }
    }
}

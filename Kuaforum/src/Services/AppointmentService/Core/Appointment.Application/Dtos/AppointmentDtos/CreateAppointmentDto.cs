using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.Dtos.AppointmentDtos
{
    public class CreateAppointmentDto
    {
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

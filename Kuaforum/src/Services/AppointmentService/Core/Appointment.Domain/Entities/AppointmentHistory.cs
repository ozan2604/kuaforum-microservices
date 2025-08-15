using Appointment.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Entities
{
    public class AppointmentHistory : BaseEntity
    {
        public Guid AppointmentId { get; set; }
        public DateTime AtUtc { get; set; } = DateTime.UtcNow;
        public string Action { get; set; } = null!;      // Created, Confirmed, Cancelled, NoShow
        public string? PerformedBy { get; set; }         // username/system
        public string? Description { get; set; }
    }
}

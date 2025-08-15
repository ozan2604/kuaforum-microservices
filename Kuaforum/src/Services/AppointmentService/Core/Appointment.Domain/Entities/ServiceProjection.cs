using Appointment.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Entities
{
    public class ServiceProjection : BaseEntity
    {
        public Guid ServiceId { get; set; }
        public Guid VenueId { get; set; }
        public string Name { get; set; } = null!;
        public string? Category { get; set; }
        public int DurationMinutes { get; set; }          // base duration
        public decimal Price { get; set; }
        public string Currency { get; set; } = "TRY";
        public bool IsActive { get; set; } = true;
    }
}

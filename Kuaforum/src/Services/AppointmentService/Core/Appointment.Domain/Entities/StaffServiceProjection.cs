using Appointment.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Entities
{
    public class StaffServiceProjection : BaseEntity
    {
        public Guid StaffId { get; set; }
        public Guid ServiceId { get; set; }
        public int? DurationMinutesOverride { get; set; }
        public decimal? PriceOverride { get; set; }
    }
}

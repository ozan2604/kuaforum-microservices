using Appointment.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Entities
{
    public class HolidayProjection : BaseEntity
    {
        public Guid? VenueId { get; set; }
        public Guid? StaffId { get; set; }
        public DateOnly Date { get; set; }
        public string? Reason { get; set; }
    }
}

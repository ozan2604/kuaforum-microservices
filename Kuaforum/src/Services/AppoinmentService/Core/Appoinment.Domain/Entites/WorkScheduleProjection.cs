using Appoinment.Domain.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appoinment.Domain.Entites
{
    public class WorkScheduleProjection : BaseEntity
    {
        public Guid StaffId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public TimeOnly? BreakStart { get; set; }
        public TimeOnly? BreakEnd { get; set; }
    }
}

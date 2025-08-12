using Catalog.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Entities
{
    public class WorkSchedule : BaseEntity
    {
        public required Guid StaffId { get; set; }
        public Staff? Staff { get; set; }

        public DayOfWeek DayOfWeek { get; set; }          // Pazartesi…Pazar
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public TimeOnly? BreakStart { get; set; }
        public TimeOnly? BreakEnd { get; set; }
    }
}

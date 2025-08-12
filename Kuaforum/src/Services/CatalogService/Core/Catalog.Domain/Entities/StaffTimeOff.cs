using Catalog.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Entities
{
    public class StaffTimeOff : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid StaffId { get; set; }
        public Staff Staff { get; set; } = null!;
        public DateTime StartUtc { get; set; }
        public DateTime EndUtc { get; set; }
        public string? Reason { get; set; }
    }
}

using Appoinment.Domain.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appoinment.Domain.Entites
{
    public class StaffTimeOffProjection : BaseEntity
    {
        public Guid StaffId { get; set; }
        public DateTime StartUtc { get; set; }
        public DateTime EndUtc { get; set; }
        public string? Reason { get; set; }
    }

}

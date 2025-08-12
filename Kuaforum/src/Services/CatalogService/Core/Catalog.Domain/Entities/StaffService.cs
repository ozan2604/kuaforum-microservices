using Catalog.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Entities
{
    public class StaffService : BaseEntity
    {
        public Guid StaffId; public Staff Staff = null!;
        public Guid ServiceId; public Service Service = null!;
        public int? DurationMinutesOverride;
        public decimal? PriceOverride;
    }

}

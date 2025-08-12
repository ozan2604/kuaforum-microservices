using Catalog.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Entities
{
    public class Holiday : BaseEntity
    {
        public Guid? VenueId { get; set; }
        public Venue? Venue { get; set; }

        public Guid? StaffId { get; set; }
        public Staff? Staff { get; set; }

        public required DateOnly Date { get; set; }
        public string? Reason { get; set; }
    }
}

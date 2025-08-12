using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Entities
{
    public class VenueTag
    {
        public Guid VenueId { get; set; }
        public Venue? Venue { get; set; }

        public Guid TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}

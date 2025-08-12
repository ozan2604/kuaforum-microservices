using Catalog.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Entities
{
    public class Like : BaseEntity
    {
        public required Guid VenueId { get; set; }
        public Venue? Venue { get; set; }

        public required Guid UserId { get; set; }
    }
}

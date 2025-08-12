using Catalog.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Entities
{
    public class VenuePhoto : BaseEntity
    {
        public required Guid VenueId { get; set; }
        public Venue? Venue { get; set; }

        public required string Url { get; set; }          // 512 char sınırı config’de
        public bool IsCover { get; set; } = false;
        public int SortOrder { get; set; } = 0;
    }
}

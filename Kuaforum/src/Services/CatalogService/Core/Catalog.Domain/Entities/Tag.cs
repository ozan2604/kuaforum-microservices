using Catalog.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public required string Name { get; set; }         // wifi, kids-friendly…
        public string? Type { get; set; }                 // Facility|Style|Brand

        public ICollection<VenueTag> VenueTags { get; set; } = new List<VenueTag>();
    }
}

using Catalog.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Entities
{
    public class Service : BaseEntity
    {
        public required Guid VenueId { get; set; }
        public Venue? Venue { get; set; }

        public required string Name { get; set; }
        public string? Category { get; set; }             // saç, boya vb.
        public int DurationMinutes { get; set; }          // 15..300
        public decimal Price { get; set; }                // 0..999999
        public string Currency { get; set; } = "TRY";
        public string? Gender { get; set; }               // opsiyonel (Men/Women/Unisex)

        public ICollection<Image> Images { get; set; } = new List<Image>();
        public ICollection<Staff> Staffs { get; set; } = new List<Staff>();
    }
}

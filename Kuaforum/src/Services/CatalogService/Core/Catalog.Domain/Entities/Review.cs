using Catalog.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Entities
{

    public class Review : BaseEntity
    {
        public required Guid VenueId { get; set; }
        public Venue? Venue { get; set; }

        public required Guid UserId { get; set; }

        public int Rating { get; set; }                   // 1..5
        public string? Comment { get; set; }
        public List<string> Photos { get; set; }   
        public bool IsVerifiedReservation { get; set; }   // Appointment onay şartı
    }
}

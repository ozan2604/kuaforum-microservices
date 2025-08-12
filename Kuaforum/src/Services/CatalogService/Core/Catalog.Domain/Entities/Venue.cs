using Catalog.Domain.Entities.Common;
using Catalog.Domain.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Entities
{
    public class Venue : BaseEntity
    {
        public required string Name { get; set; }
        public VenueType Type { get; set; }
        public string? Description { get; set; }

        public required string Phone { get; set; }
        public required string Email { get; set; }
        public string? Website { get; set; }

        // Adres
        public required string FullAddress { get; set; }
        public required string City { get; set; }
        public required string Town { get; set; }
        public required string Country { get; set; }
        public string? PostalCode { get; set; }

        // Konum (PostGIS/NTS Point; SRID 4326)
        public Point? Location { get; set; }

        // Rating özetleri
        public decimal AvgRating { get; set; } = 0m;     // 0..5, 2 ondalık
        public int RatingsCount { get; set; } = 0;


        // Navigations
        public ICollection<VenuePhoto> Photos { get; set; } = new List<VenuePhoto>();
        public ICollection<Staff> Staff { get; set; } = new List<Staff>();
        public ICollection<Service> Services { get; set; } = new List<Service>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Like> Likes { get; set; } = new List<Like>();
        public ICollection<VenueTag> VenueTags { get; set; } = new List<VenueTag>();
    }
}

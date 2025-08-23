using Catalog.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Dtos.VenueDtos
{
    public class ResultVenueDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public VenueType Type { get; set; }
        public string? Description { get; set; }
        public string Phone { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string? Website { get; set; }
        public string FullAddress { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Town { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string? PostalCode { get; set; }
        public decimal AvgRating { get; set; }
        public int RatingsCount { get; set; }

        // İstersen liste ekranı için özet alanlar:
        public int PhotosCount { get; set; }
        public int ServicesCount { get; set; }
        public int StaffCount { get; set; }
        public int ReviewsCount { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreateUserName { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdateUserName { get; set; }
    }
}

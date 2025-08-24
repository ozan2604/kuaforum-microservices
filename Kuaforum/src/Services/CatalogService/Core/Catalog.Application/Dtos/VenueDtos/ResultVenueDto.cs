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
        public bool IsActive { get; set; } = true;
        public DateTime? CreatedAt { get; set; }
        public Guid? CreateUserId { get; set; } = default!;
        public string CreateUserName { get; set; } = string.Empty;
        public string? UpdateUserName { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdateUserId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public Guid? DeleteUserId { get; set; }
        public required string Name { get; set; }
        public VenueType Type { get; set; }
        public string? Description { get; set; }

        public required string Phone { get; set; }
        public required string Email { get; set; }
        public string? Website { get; set; }
        public required string FullAddress { get; set; }
        public required string City { get; set; }
        public required string Town { get; set; }
        public required string Country { get; set; }
        public string? PostalCode { get; set; }
        public decimal AvgRating { get; set; } = 0m;
        public int RatingsCount { get; set; } = 0;

        // İstersen liste ekranı için özet alanlar:
        public int PhotosCount { get; set; }
        public int ServicesCount { get; set; }
        public int StaffCount { get; set; }
        public int ReviewsCount { get; set; }
        
    }
}

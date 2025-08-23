using Catalog.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Dtos.VenueDtos
{
    public class CreateVenueDto
    {
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
    }
}

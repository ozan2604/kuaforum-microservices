using System;

namespace Catalog.Application.Dtos.VenueTagDtos;

public class CreateVenueTagDto
{
    public Guid VenueId { get; set; }
    public Guid TagId { get; set; }
}

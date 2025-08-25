using System;

namespace Catalog.Application.Dtos.ImageDtos;

public class CreateImageDto
{
    public required string Url { get; set; }
    public bool IsCover { get; set; } = false;
    public int SortOrder { get; set; } = 0;
    public Guid VenueId { get; set; }
    public Guid ServiceId { get; set; }
}

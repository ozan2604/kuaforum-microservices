using System;
using System.Collections.Generic;

namespace Catalog.Application.Dtos.ReviewDtos;

public class CreateReviewDto
{
    public required Guid VenueId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public List<string>? Photos { get; set; }
    public bool IsVerifiedReservation { get; set; }
}

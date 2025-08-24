using System;

namespace Catalog.Application.Dtos.LikeDtos;

public class CreateLikeDto
{
    public Guid VenueId { get; set; }
    public Guid UserId { get; set; }
}

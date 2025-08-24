using System;

namespace Catalog.Application.Dtos.LikeDtos;

public class UpdateLikeDto : CreateLikeDto
{
    public Guid Id { get; set; }
}

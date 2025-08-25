using System;

namespace Catalog.Application.Dtos.ImageDtos;

public class UpdateImageDto : CreateImageDto
{
    public Guid Id { get; set; }
}

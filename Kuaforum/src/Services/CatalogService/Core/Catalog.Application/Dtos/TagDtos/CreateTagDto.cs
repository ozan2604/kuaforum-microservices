namespace Catalog.Application.Dtos.TagDtos;

public class CreateTagDto
{
    public required string Name { get; set; }
    public string? Type { get; set; }
}

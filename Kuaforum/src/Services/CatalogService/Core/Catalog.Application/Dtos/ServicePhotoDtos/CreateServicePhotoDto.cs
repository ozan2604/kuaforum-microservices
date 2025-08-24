namespace Catalog.Application.Dtos.ServicePhotoDtos;

public class CreateServicePhotoDto
{
    public Guid ServiceId { get; set; }
    public required string Url { get; set; }
    public bool IsCover { get; set; }
    public int SortOrder { get; set; }
}

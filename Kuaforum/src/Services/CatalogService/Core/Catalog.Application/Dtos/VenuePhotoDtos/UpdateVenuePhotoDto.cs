namespace Catalog.Application.Dtos.VenuePhotoDtos;

public class UpdateVenuePhotoDto
{
    public Guid Id { get; set; }
    public Guid VenueId { get; set; }
    public required string Url { get; set; }
    public bool IsCover { get; set; }
    public int SortOrder { get; set; }
}

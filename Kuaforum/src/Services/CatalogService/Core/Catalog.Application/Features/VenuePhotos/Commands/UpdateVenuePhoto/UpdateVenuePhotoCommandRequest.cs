using Application.Results;
using Catalog.Application.Dtos.VenuePhotoDtos;
using MediatR;

namespace Catalog.Application.Features.VenuePhotos.Commands.UpdateVenuePhoto;

public class UpdateVenuePhotoCommandRequest : IRequest<Result>
{
    public required UpdateVenuePhotoDto Photo { get; set; }
}

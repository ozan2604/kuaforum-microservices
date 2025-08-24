using Application.Results;
using Catalog.Application.Dtos.VenuePhotoDtos;
using MediatR;

namespace Catalog.Application.Features.VenuePhotos.Commands.CreateVenuePhoto;

public class CreateVenuePhotoCommandRequest : IRequest<Result<Guid>>
{
    public required CreateVenuePhotoDto Photo { get; set; }
}

using Application.Results;
using MediatR;

namespace Catalog.Application.Features.VenuePhotos.Commands.DeleteVenuePhoto;

public class DeleteVenuePhotoCommandRequest : IRequest<Result>
{
    public Guid Id { get; set; }
}

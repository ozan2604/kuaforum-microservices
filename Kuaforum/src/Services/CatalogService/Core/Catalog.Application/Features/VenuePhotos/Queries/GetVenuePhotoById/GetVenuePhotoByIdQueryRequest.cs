using Application.Results;
using Catalog.Application.Dtos.VenuePhotoDtos;
using MediatR;

namespace Catalog.Application.Features.VenuePhotos.Queries.GetVenuePhotoById;

public class GetVenuePhotoByIdQueryRequest : IRequest<Result<ResultVenuePhotoDto>>
{
    public Guid Id { get; set; }
}

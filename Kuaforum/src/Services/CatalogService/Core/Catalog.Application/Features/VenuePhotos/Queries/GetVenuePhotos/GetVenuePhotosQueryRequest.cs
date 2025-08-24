using Application.Results;
using Catalog.Application.Dtos.VenuePhotoDtos;
using MediatR;

namespace Catalog.Application.Features.VenuePhotos.Queries.GetVenuePhotos;

public class GetVenuePhotosQueryRequest : IRequest<Result<List<ResultVenuePhotoDto>>>
{
}

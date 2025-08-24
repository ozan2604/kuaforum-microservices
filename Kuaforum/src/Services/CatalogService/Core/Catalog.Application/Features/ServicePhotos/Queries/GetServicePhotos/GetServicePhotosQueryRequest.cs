using Application.Results;
using Catalog.Application.Dtos.ServicePhotoDtos;
using MediatR;

namespace Catalog.Application.Features.ServicePhotos.Queries.GetServicePhotos;

public class GetServicePhotosQueryRequest : IRequest<Result<List<ResultServicePhotoDto>>>
{
}

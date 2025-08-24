using Application.Results;
using Catalog.Application.Dtos.ServicePhotoDtos;
using MediatR;

namespace Catalog.Application.Features.ServicePhotos.Queries.GetServicePhotoById;

public class GetServicePhotoByIdQueryRequest : IRequest<Result<ResultServicePhotoDto>>
{
    public Guid Id { get; set; }
}

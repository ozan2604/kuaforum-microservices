using Application.Results;
using Catalog.Application.Dtos.ImageDtos;
using MediatR;

namespace Catalog.Application.Features.Images.Queries.GetImageById;

public class GetImageByIdQueryRequest : IRequest<Result<ResultImageDto>>
{
    public Guid Id { get; set; }
}

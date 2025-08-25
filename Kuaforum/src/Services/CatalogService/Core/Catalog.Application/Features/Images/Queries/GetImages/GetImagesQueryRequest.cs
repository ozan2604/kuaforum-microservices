using Application.Results;
using Catalog.Application.Dtos.ImageDtos;
using MediatR;

namespace Catalog.Application.Features.Images.Queries.GetImages;

public class GetImagesQueryRequest : IRequest<Result<List<ResultImageDto>>>
{
}

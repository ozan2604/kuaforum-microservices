using Application.Results;
using Catalog.Application.Dtos.TagDtos;
using MediatR;

namespace Catalog.Application.Features.Tags.Queries.GetTags;

public class GetTagsQueryRequest : IRequest<Result<List<ResultTagDto>>>
{
}

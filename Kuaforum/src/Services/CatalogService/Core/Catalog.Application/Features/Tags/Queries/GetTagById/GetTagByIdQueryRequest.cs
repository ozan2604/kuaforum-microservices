using Application.Results;
using Catalog.Application.Dtos.TagDtos;
using MediatR;

namespace Catalog.Application.Features.Tags.Queries.GetTagById;

public class GetTagByIdQueryRequest : IRequest<Result<ResultTagDto>>
{
    public Guid Id { get; set; }
}

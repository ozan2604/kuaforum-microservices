using Application.Results;
using Catalog.Application.Dtos.LikeDtos;
using MediatR;

namespace Catalog.Application.Features.Likes.Queries.GetLikeById;

public class GetLikeByIdQueryRequest : IRequest<Result<ResultLikeDto>>
{
    public Guid Id { get; set; }
}

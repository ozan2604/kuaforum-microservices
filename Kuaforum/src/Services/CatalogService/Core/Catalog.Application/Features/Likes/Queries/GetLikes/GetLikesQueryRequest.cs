using Application.Results;
using Catalog.Application.Dtos.LikeDtos;
using MediatR;

namespace Catalog.Application.Features.Likes.Queries.GetLikes;

public class GetLikesQueryRequest : IRequest<Result<List<ResultLikeDto>>>
{
}

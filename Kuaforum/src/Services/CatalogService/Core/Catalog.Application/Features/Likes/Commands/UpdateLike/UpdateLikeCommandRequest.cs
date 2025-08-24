using Application.Results;
using Catalog.Application.Dtos.LikeDtos;
using MediatR;

namespace Catalog.Application.Features.Likes.Commands.UpdateLike;

public class UpdateLikeCommandRequest : IRequest<Result<Guid>>
{
    public required UpdateLikeDto Like { get; set; }
}

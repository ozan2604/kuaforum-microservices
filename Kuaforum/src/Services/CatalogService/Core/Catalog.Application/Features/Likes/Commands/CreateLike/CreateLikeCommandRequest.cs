using Application.Results;
using Catalog.Application.Dtos.LikeDtos;
using MediatR;

namespace Catalog.Application.Features.Likes.Commands.CreateLike;

public class CreateLikeCommandRequest : IRequest<Result<Guid>>
{
    public required CreateLikeDto Like { get; set; }
}

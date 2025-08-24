using Application.Results;
using MediatR;

namespace Catalog.Application.Features.Likes.Commands.DeleteLike;

public class DeleteLikeCommandRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}

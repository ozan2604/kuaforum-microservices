using Application.Results;
using MediatR;

namespace Catalog.Application.Features.Images.Commands.DeleteImage;

public class DeleteImageCommandRequest : IRequest<Result>
{
    public Guid Id { get; set; }
}

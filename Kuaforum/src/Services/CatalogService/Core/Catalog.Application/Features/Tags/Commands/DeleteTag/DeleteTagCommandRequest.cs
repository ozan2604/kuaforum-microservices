using Application.Results;
using MediatR;

namespace Catalog.Application.Features.Tags.Commands.DeleteTag;

public class DeleteTagCommandRequest : IRequest<Result>
{
    public Guid Id { get; set; }
}

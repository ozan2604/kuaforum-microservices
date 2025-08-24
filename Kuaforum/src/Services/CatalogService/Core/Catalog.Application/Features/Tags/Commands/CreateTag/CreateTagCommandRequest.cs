using Catalog.Application.Dtos.TagDtos;
using Application.Results;
using MediatR;

namespace Catalog.Application.Features.Tags.Commands.CreateTag;

public class CreateTagCommandRequest : IRequest<Result<Guid>>
{
    public required CreateTagDto Tag { get; set; }
}

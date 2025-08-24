using Catalog.Application.Dtos.TagDtos;
using Application.Results;
using MediatR;

namespace Catalog.Application.Features.Tags.Commands.UpdateTag;

public class UpdateTagCommandRequest : IRequest<Result>
{
    public required UpdateTagDto Tag { get; set; }
}

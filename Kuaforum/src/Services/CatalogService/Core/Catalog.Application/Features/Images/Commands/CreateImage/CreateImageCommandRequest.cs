using Catalog.Application.Dtos.ImageDtos;
using Application.Results;
using MediatR;

namespace Catalog.Application.Features.Images.Commands.CreateImage;

public class CreateImageCommandRequest : IRequest<Result<Guid>>
{
    public required CreateImageDto Image { get; set; }
}

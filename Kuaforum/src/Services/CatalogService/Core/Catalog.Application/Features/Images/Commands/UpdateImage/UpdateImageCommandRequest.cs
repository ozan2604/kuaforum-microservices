using Catalog.Application.Dtos.ImageDtos;
using Application.Results;
using MediatR;

namespace Catalog.Application.Features.Images.Commands.UpdateImage;

public class UpdateImageCommandRequest : IRequest<Result>
{
    public required UpdateImageDto Image { get; set; }
}

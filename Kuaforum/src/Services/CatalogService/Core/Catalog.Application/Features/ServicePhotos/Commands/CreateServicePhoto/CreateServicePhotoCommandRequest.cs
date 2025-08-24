using Application.Results;
using Catalog.Application.Dtos.ServicePhotoDtos;
using MediatR;

namespace Catalog.Application.Features.ServicePhotos.Commands.CreateServicePhoto;

public class CreateServicePhotoCommandRequest : IRequest<Result<Guid>>
{
    public required CreateServicePhotoDto Photo { get; set; }
}

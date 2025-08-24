using Application.Results;
using Catalog.Application.Dtos.ServicePhotoDtos;
using MediatR;

namespace Catalog.Application.Features.ServicePhotos.Commands.UpdateServicePhoto;

public class UpdateServicePhotoCommandRequest : IRequest<Result>
{
    public required UpdateServicePhotoDto Photo { get; set; }
}

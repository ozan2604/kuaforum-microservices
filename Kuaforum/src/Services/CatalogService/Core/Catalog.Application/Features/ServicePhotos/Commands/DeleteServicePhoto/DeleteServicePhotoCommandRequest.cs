using Application.Results;
using MediatR;

namespace Catalog.Application.Features.ServicePhotos.Commands.DeleteServicePhoto;

public class DeleteServicePhotoCommandRequest : IRequest<Result>
{
    public Guid Id { get; set; }
}

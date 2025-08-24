using Application.Results;
using Catalog.Application.Repositories.ServicePhotoRepository;
using Catalog.Application.Services.CurrentUserServices;
using MediatR;

namespace Catalog.Application.Features.ServicePhotos.Commands.DeleteServicePhoto;

public class DeleteServicePhotoCommandHandler : IRequestHandler<DeleteServicePhotoCommandRequest, Result>
{
    private readonly IServicePhotoRepository _repository;
    private readonly ICurrentUserService _current;

    public DeleteServicePhotoCommandHandler(IServicePhotoRepository repository, ICurrentUserService current)
    {
        _repository = repository;
        _current = current;
    }

    public async Task<Result> Handle(DeleteServicePhotoCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);
        if (entity == null)
            return Result.FailureResult("Silinecek veri bulunamadı.");

        entity.IsDeleted = true;
        entity.DeletedAt = DateTime.UtcNow;
        entity.DeleteUserId = _current.UserId;
        entity.UpdateUserName = _current.UserName ?? string.Empty;
        entity.UpdateUserId = _current.UserId;
        entity.UpdatedAt = DateTime.UtcNow;

        var updated = _repository.Update(entity);
        if (!updated)
            return Result.FailureResult("Silme başarısız.");

        var saved = await _repository.SaveAsync();
        return saved > 0
            ? Result.SuccessResult("Başarıyla silindi.")
            : Result.FailureResult("Veritabanına silme yansıtılamadı.");
    }
}

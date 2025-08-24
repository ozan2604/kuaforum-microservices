using Application.Results;
using Catalog.Application.Repositories.LikeRepository;
using Catalog.Application.Services.CurrentUserServices;
using MediatR;

namespace Catalog.Application.Features.Likes.Commands.DeleteLike;

public class DeleteLikeCommandHandler : IRequestHandler<DeleteLikeCommandRequest, Result<Guid>>
{
    private readonly ILikeRepository _repository;
    private readonly ICurrentUserService _current;

    public DeleteLikeCommandHandler(ILikeRepository repository, ICurrentUserService current)
    {
        _repository = repository;
        _current = current;
    }

    public async Task<Result<Guid>> Handle(DeleteLikeCommandRequest request, CancellationToken ct)
    {
        var like = await _repository.GetByIdAsync(request.Id);
        if (like == null) return Result<Guid>.FailureResult("Bulunamadı.");

        like.IsDeleted = true;
        like.DeletedAt = DateTime.UtcNow;
        like.DeleteUserId = _current.UserId;

        _repository.Update(like);
        var saved = await _repository.SaveAsync();
        return saved > 0
            ? Result<Guid>.SuccessResult(like.Id, "Başarıyla silindi.")
            : Result<Guid>.FailureResult("Silme başarısız.");
    }
}

using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.LikeDtos;
using Catalog.Application.Repositories.LikeRepository;
using Catalog.Application.Services.CurrentUserServices;
using MediatR;

namespace Catalog.Application.Features.Likes.Commands.UpdateLike;

public class UpdateLikeCommandHandler : IRequestHandler<UpdateLikeCommandRequest, Result<Guid>>
{
    private readonly ILikeRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _current;

    public UpdateLikeCommandHandler(ILikeRepository repository, IMapper mapper, ICurrentUserService current)
    {
        _repository = repository;
        _mapper = mapper;
        _current = current;
    }

    public async Task<Result<Guid>> Handle(UpdateLikeCommandRequest request, CancellationToken ct)
    {
        var like = await _repository.GetByIdAsync(request.Like.Id);
        if (like == null) return Result<Guid>.FailureResult("Bulunamadı.");

        _mapper.Map(request.Like, like);
        like.UpdatedAt = DateTime.UtcNow;
        like.UpdateUserId = _current.UserId;
        like.UpdateUserName = _current.UserName;

        _repository.Update(like);
        var saved = await _repository.SaveAsync();
        return saved > 0
            ? Result<Guid>.SuccessResult(like.Id, "Başarıyla güncellendi.")
            : Result<Guid>.FailureResult("Güncelleme başarısız.");
    }
}

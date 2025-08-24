using Application.Results;
using AutoMapper;
using Catalog.Application.Repositories.ReviewRepository;
using Catalog.Application.Services.CurrentUserServices;
using MediatR;

namespace Catalog.Application.Features.Reviews.Commands.UpdateReview;

public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommandRequest, Result>
{
    private readonly IReviewRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _current;

    public UpdateReviewCommandHandler(IReviewRepository repository, IMapper mapper, ICurrentUserService current)
    {
        _repository = repository;
        _mapper = mapper;
        _current = current;
    }

    public async Task<Result> Handle(UpdateReviewCommandRequest request, CancellationToken cancellationToken)
    {
        var dto = request.Review;
        var entity = await _repository.GetByIdAsync(dto.Id);
        if (entity == null)
            return Result.FailureResult("Güncellenecek veri bulunamadı.");

        _mapper.Map(dto, entity);
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdateUserId = _current.UserId;
        entity.UpdateUserName = _current.UserName ?? string.Empty;

        var updated = _repository.Update(entity);
        if (!updated)
            return Result.FailureResult("Güncelleme başarısız.");

        var saved = await _repository.SaveAsync();
        return saved > 0
            ? Result.SuccessResult("Başarıyla güncellendi.")
            : Result.FailureResult("Veritabanına güncelleme yansıtılamadı.");
    }
}

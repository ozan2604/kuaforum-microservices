using Application.Results;
using AutoMapper;
using Catalog.Application.Repositories.StaffTimeOffRepository;
using Catalog.Application.Services.CurrentUserServices;
using MediatR;

namespace Catalog.Application.Features.StaffTimeOffs.Commands.UpdateStaffTimeOff;

public class UpdateStaffTimeOffCommandHandler : IRequestHandler<UpdateStaffTimeOffCommandRequest, Result>
{
    private readonly IStaffTimeOffRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _current;

    public UpdateStaffTimeOffCommandHandler(IStaffTimeOffRepository repository, IMapper mapper, ICurrentUserService current)
    {
        _repository = repository;
        _mapper = mapper;
        _current = current;
    }

    public async Task<Result> Handle(UpdateStaffTimeOffCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.TimeOff.Id);
        if (entity == null)
            return Result.FailureResult("Güncellenecek veri bulunamadı.");

        entity = _mapper.Map(request.TimeOff, entity);
        entity.UpdateUserId = _current.UserId;
        entity.UpdateUserName = _current.UserName ?? string.Empty;
        entity.UpdatedAt = DateTime.UtcNow;

        var updated = _repository.Update(entity);
        if (!updated)
            return Result.FailureResult("Güncelleme başarısız.");

        var saved = await _repository.SaveAsync();
        return saved > 0
            ? Result.SuccessResult("Başarıyla güncellendi.")
            : Result.FailureResult("Veritabanına kaydedilemedi.");
    }
}

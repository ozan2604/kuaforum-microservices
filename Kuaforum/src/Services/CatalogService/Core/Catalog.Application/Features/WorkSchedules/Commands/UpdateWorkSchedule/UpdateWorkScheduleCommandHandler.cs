using Application.Results;
using AutoMapper;
using Catalog.Application.Repositories.WorkScheduleRepository;
using Catalog.Application.Services.CurrentUserServices;
using MediatR;

namespace Catalog.Application.Features.WorkSchedules.Commands.UpdateWorkSchedule;

public class UpdateWorkScheduleCommandHandler : IRequestHandler<UpdateWorkScheduleCommandRequest, Result<Guid>>
{
    private readonly IWorkScheduleRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _current;

    public UpdateWorkScheduleCommandHandler(IWorkScheduleRepository repository, IMapper mapper, ICurrentUserService current)
    {
        _repository = repository;
        _mapper = mapper;
        _current = current;
    }

    public async Task<Result<Guid>> Handle(UpdateWorkScheduleCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.WorkSchedule.Id);
        if (entity == null)
            return Result<Guid>.FailureResult("Kayıt bulunamadı.");

        _mapper.Map(request.WorkSchedule, entity);
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdateUserId = _current.UserId;
        entity.UpdateUserName = _current.UserName ?? string.Empty;

        var updated = _repository.Update(entity);
        if (!updated)
            return Result<Guid>.FailureResult("Güncelleme başarısız.");

        var saved = await _repository.SaveAsync();
        return saved > 0
            ? Result<Guid>.SuccessResult(entity.Id, "Başarıyla güncellendi.")
            : Result<Guid>.FailureResult("Veritabanına kaydedilemedi.");
    }
}

using Application.Results;
using AutoMapper;
using Catalog.Application.Repositories.StaffServiceRepository;
using Catalog.Application.Services.CurrentUserServices;
using MediatR;

namespace Catalog.Application.Features.StaffServices.Commands.UpdateStaffService;

public class UpdateStaffServiceCommandHandler : IRequestHandler<UpdateStaffServiceCommandRequest, Result>
{
    private readonly IStaffServiceRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _current;

    public UpdateStaffServiceCommandHandler(IStaffServiceRepository repository, IMapper mapper, ICurrentUserService current)
    {
        _repository = repository;
        _mapper = mapper;
        _current = current;
    }

    public async Task<Result> Handle(UpdateStaffServiceCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.StaffService.Id);
        if (entity == null)
            return Result.FailureResult("Güncellenecek veri bulunamadı.");

        entity = _mapper.Map(request.StaffService, entity);
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

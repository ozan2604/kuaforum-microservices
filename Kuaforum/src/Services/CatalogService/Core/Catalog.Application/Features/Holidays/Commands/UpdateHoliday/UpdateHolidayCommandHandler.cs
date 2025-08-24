using Application.Results;
using AutoMapper;
using Catalog.Application.Repositories.HolidayRepository;
using Catalog.Application.Services.CurrentUserServices;
using MediatR;

namespace Catalog.Application.Features.Holidays.Commands.UpdateHoliday;

public class UpdateHolidayCommandHandler : IRequestHandler<UpdateHolidayCommandRequest, Result<Guid>>
{
    private readonly IHolidayRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _current;

    public UpdateHolidayCommandHandler(IHolidayRepository repository, IMapper mapper, ICurrentUserService current)
    {
        _repository = repository;
        _mapper = mapper;
        _current = current;
    }

    public async Task<Result<Guid>> Handle(UpdateHolidayCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Holiday.Id);
        if (entity == null)
            return Result<Guid>.FailureResult("Kayıt bulunamadı.");

        _mapper.Map(request.Holiday, entity);
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

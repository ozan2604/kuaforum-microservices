using Application.Results;
using Catalog.Application.Repositories.HolidayRepository;
using MediatR;

namespace Catalog.Application.Features.Holidays.Commands.DeleteHoliday;

public class DeleteHolidayCommandHandler : IRequestHandler<DeleteHolidayCommandRequest, Result<Guid>>
{
    private readonly IHolidayRepository _repository;

    public DeleteHolidayCommandHandler(IHolidayRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Guid>> Handle(DeleteHolidayCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);
        if (entity == null)
            return Result<Guid>.FailureResult("Kayıt bulunamadı.");

        var removed = await _repository.RemoveAsync(request.Id);
        if (!removed)
            return Result<Guid>.FailureResult("Silme işlemi başarısız.");

        var saved = await _repository.SaveAsync();
        return saved > 0
            ? Result<Guid>.SuccessResult(request.Id, "Başarıyla silindi.")
            : Result<Guid>.FailureResult("Veritabanına kaydedilemedi.");
    }
}

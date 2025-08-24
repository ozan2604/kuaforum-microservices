using Application.Results;
using Catalog.Application.Repositories.WorkScheduleRepository;
using MediatR;

namespace Catalog.Application.Features.WorkSchedules.Commands.DeleteWorkSchedule;

public class DeleteWorkScheduleCommandHandler : IRequestHandler<DeleteWorkScheduleCommandRequest, Result<Guid>>
{
    private readonly IWorkScheduleRepository _repository;

    public DeleteWorkScheduleCommandHandler(IWorkScheduleRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Guid>> Handle(DeleteWorkScheduleCommandRequest request, CancellationToken cancellationToken)
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

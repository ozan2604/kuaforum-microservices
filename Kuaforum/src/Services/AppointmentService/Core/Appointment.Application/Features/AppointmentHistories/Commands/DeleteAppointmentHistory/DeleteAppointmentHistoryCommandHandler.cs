using Appointment.Application.Repositories.AppointmentHistoryRepositories;
using Appointment.Application.Results;
using MediatR;

namespace Appointment.Application.Features.AppointmentHistories.Commands.DeleteAppointmentHistory;

public class DeleteAppointmentHistoryCommandHandler : IRequestHandler<DeleteAppointmentHistoryCommandRequest, Result<Guid>>
{
    private readonly IAppointmentHistoryRepository _repository;

    public DeleteAppointmentHistoryCommandHandler(IAppointmentHistoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Guid>> Handle(DeleteAppointmentHistoryCommandRequest request, CancellationToken cancellationToken)
    {
        var removed = await _repository.RemoveAsync(request.Id);
        if (!removed)
            return Result<Guid>.FailureResult("Silme başarısız.");

        var saved = await _repository.SaveAsync(cancellationToken);
        return saved > 0
            ? Result<Guid>.SuccessResult(request.Id, "Başarıyla silindi.")
            : Result<Guid>.FailureResult("Veritabanına kaydedilemedi.");
    }
}

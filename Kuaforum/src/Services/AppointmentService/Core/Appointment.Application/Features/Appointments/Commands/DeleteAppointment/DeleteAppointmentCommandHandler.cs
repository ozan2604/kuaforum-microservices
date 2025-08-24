using Appointment.Application.Repositories.AppointmentRepositories;
using Appointment.Application.Results;
using MediatR;

namespace Appointment.Application.Features.Appointments.Commands.DeleteAppointment;

public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommandRequest, Result<Guid>>
{
    private readonly IAppointmentRepository _repository;

    public DeleteAppointmentCommandHandler(IAppointmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Guid>> Handle(DeleteAppointmentCommandRequest request, CancellationToken cancellationToken)
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

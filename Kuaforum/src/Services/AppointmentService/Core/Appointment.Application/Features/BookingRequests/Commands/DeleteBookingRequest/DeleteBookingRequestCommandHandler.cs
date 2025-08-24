using Appointment.Application.Repositories.BookingRequestRepositories;
using Appointment.Application.Results;
using MediatR;

namespace Appointment.Application.Features.BookingRequests.Commands.DeleteBookingRequest;

public class DeleteBookingRequestCommandHandler : IRequestHandler<DeleteBookingRequestCommandRequest, Result<Guid>>
{
    private readonly IBookingRequestRepository _repository;

    public DeleteBookingRequestCommandHandler(IBookingRequestRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Guid>> Handle(DeleteBookingRequestCommandRequest request, CancellationToken cancellationToken)
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

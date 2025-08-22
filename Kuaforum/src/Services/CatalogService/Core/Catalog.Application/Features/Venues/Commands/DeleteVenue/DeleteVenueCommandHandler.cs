using Application.Results;
using Catalog.Application.Repositories.VenueRepository;
using MediatR;

namespace Catalog.Application.Features.Venues.Commands.DeleteVenue;

public class DeleteVenueCommandHandler : IRequestHandler<DeleteVenueCommandRequest, Result>
{
    private readonly IVenueRepository _repository;

    public DeleteVenueCommandHandler(IVenueRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(DeleteVenueCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);
        if (entity == null)
            return Result.FailureResult("Silinecek veri bulunamadı.");

        var removed = _repository.Remove(entity);
        if (!removed)
            return Result.FailureResult("Silme başarısız.");

        var saved = await _repository.SaveAsync();
        return saved > 0
            ? Result.SuccessResult("Başarıyla silindi.")
            : Result.FailureResult("Veritabanına silme yansıtılamadı.");
    }
}

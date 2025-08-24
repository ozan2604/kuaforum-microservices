using Application.Results;
using Catalog.Application.Repositories.VenueTagRepository;
using MediatR;

namespace Catalog.Application.Features.VenueTags.Commands.DeleteVenueTag;

public class DeleteVenueTagCommandHandler : IRequestHandler<DeleteVenueTagCommandRequest, Result>
{
    private readonly IVenueTagRepository _repository;

    public DeleteVenueTagCommandHandler(IVenueTagRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(DeleteVenueTagCommandRequest request, CancellationToken cancellationToken)
    {
        var removed = await _repository.RemoveByIdsAsync(request.VenueId, request.TagId);
        if (!removed)
            return Result.FailureResult("Silinecek veri bulunamadı.");

        var saved = await _repository.SaveAsync();
        return saved > 0
            ? Result.SuccessResult("Başarıyla silindi.")
            : Result.FailureResult("Veritabanına kaydedilemedi.");
    }
}

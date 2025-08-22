using Application.Results;
using AutoMapper;
using Catalog.Application.Repositories.VenueRepository;
using MediatR;

namespace Catalog.Application.Features.Venues.Commands.UpdateVenue;

public class UpdateVenueCommandHandler : IRequestHandler<UpdateVenueCommandRequest, Result>
{
    private readonly IVenueRepository _repository;
    private readonly IMapper _mapper;

    public UpdateVenueCommandHandler(IVenueRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result> Handle(UpdateVenueCommandRequest request, CancellationToken cancellationToken)
    {
        var dto = request.Venue;
        var entity = await _repository.GetByIdAsync(dto.Id);
        if (entity == null)
            return Result.FailureResult("Güncellenecek veri bulunamadı.");

        _mapper.Map(dto, entity);
        entity.UpdatedAt = DateTime.UtcNow;

        var updated = _repository.Update(entity);
        if (!updated)
            return Result.FailureResult("Güncelleme başarısız.");

        var saved = await _repository.SaveAsync();
        return saved > 0
            ? Result.SuccessResult("Başarıyla güncellendi.")
            : Result.FailureResult("Veritabanına güncelleme yansıtılamadı.");
    }
}

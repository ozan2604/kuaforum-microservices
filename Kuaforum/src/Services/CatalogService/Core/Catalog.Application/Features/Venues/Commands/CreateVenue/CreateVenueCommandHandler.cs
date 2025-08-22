using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.VenueDtos;
using Catalog.Application.Repositories.VenueRepository;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Features.Venues.Commands.CreateVenue;

public class CreateVenueCommandHandler : IRequestHandler<CreateVenueCommandRequest, Result<Guid>>
{
    private readonly IVenueRepository _repository;
    private readonly IMapper _mapper;

    public CreateVenueCommandHandler(IVenueRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<Guid>> Handle(CreateVenueCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Venue>(request.Venue);
        entity.CreatedAt = DateTime.UtcNow;

        var added = await _repository.AddAsync(entity);
        if (!added)
            return Result<Guid>.FailureResult("Ekleme başarısız.");

        var saved = await _repository.SaveAsync();
        return saved > 0
            ? Result<Guid>.SuccessResult(entity.Id, "Başarıyla eklendi.")
            : Result<Guid>.FailureResult("Veritabanına kaydedilemedi.");
    }
}

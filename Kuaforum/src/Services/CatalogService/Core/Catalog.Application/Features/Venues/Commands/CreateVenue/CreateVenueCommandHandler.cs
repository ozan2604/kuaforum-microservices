using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.VenueDtos;
using Catalog.Application.Repositories.VenueRepository;
using Catalog.Application.Services.CurrentUserServices;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Features.Venues.Commands.CreateVenue;

public sealed class CreateVenueCommandHandler
    : IRequestHandler<CreateVenueCommandRequest, Result<Guid>>
{
    private readonly IVenueRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _current; // userId, userName

    public CreateVenueCommandHandler(
        IVenueRepository repository, IMapper mapper, ICurrentUserService current)
    {
        _repository = repository;
        _mapper = mapper;
        _current = current;
    }

    public async Task<Result<Guid>> Handle(CreateVenueCommandRequest request, CancellationToken ct)
    {
        var entity = _mapper.Map<Venue>(request.Venue);

        entity.IsActive = true;
        entity.IsDeleted = false;
        entity.CreatedAt = DateTime.UtcNow;
        entity.CreateUserId = _current.UserId;          // Guid?
        entity.CreateUserName = _current.UserName ?? "";

        var added = await _repository.AddAsync(entity);
        if (!added) return Result<Guid>.FailureResult("Ekleme başarısız.");

        var saved = await _repository.SaveAsync();
        return saved > 0
            ? Result<Guid>.SuccessResult(entity.Id, "Başarıyla eklendi.")
            : Result<Guid>.FailureResult("Veritabanına kaydedilemedi.");
    }
}

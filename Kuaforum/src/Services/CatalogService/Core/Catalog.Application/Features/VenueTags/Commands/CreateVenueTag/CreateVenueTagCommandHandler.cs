using Application.Results;
using AutoMapper;
using Catalog.Application.Repositories.VenueTagRepository;
using Catalog.Application.Services.CurrentUserServices;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Features.VenueTags.Commands.CreateVenueTag;

public class CreateVenueTagCommandHandler : IRequestHandler<CreateVenueTagCommandRequest, Result>
{
    private readonly IVenueTagRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _current;

    public CreateVenueTagCommandHandler(IVenueTagRepository repository, IMapper mapper, ICurrentUserService current)
    {
        _repository = repository;
        _mapper = mapper;
        _current = current;
    }

    public async Task<Result> Handle(CreateVenueTagCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<VenueTag>(request.VenueTag);
        entity.IsActive = true;
        entity.IsDeleted = false;
        entity.CreatedAt = DateTime.UtcNow;
        entity.CreateUserId = _current.UserId;          // Guid?
        entity.CreateUserName = _current.UserName ?? "";

        var added = await _repository.AddAsync(entity);
        if (!added)
            return Result.FailureResult("Ekleme başarısız.");

        var saved = await _repository.SaveAsync();
        return saved > 0
            ? Result.SuccessResult("Başarıyla eklendi.")
            : Result.FailureResult("Veritabanına kaydedilemedi.");
    }
}

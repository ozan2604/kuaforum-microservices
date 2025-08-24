using Application.Results;
using AutoMapper;
using Catalog.Application.Repositories.VenueTagRepository;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Features.VenueTags.Commands.CreateVenueTag;

public class CreateVenueTagCommandHandler : IRequestHandler<CreateVenueTagCommandRequest, Result>
{
    private readonly IVenueTagRepository _repository;
    private readonly IMapper _mapper;

    public CreateVenueTagCommandHandler(IVenueTagRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result> Handle(CreateVenueTagCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<VenueTag>(request.VenueTag);
        var added = await _repository.AddAsync(entity);
        if (!added)
            return Result.FailureResult("Ekleme başarısız.");

        var saved = await _repository.SaveAsync();
        return saved > 0
            ? Result.SuccessResult("Başarıyla eklendi.")
            : Result.FailureResult("Veritabanına kaydedilemedi.");
    }
}

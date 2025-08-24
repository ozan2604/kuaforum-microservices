using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.VenueTagDtos;
using Catalog.Application.Repositories.VenueTagRepository;
using MediatR;

namespace Catalog.Application.Features.VenueTags.Queries.GetVenueTagById;

public class GetVenueTagByIdQueryHandler : IRequestHandler<GetVenueTagByIdQueryRequest, Result<VenueTagDto>>
{
    private readonly IVenueTagRepository _repository;
    private readonly IMapper _mapper;

    public GetVenueTagByIdQueryHandler(IVenueTagRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<VenueTagDto>> Handle(GetVenueTagByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdsAsync(request.VenueId, request.TagId);
        if (entity == null)
            return Result<VenueTagDto>.FailureResult("Kayıt bulunamadı.");

        var dto = _mapper.Map<VenueTagDto>(entity);
        return Result<VenueTagDto>.SuccessResult(dto);
    }
}

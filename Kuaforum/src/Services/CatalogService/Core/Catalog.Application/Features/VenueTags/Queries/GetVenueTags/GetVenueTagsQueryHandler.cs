using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.VenueTagDtos;
using Catalog.Application.Repositories.VenueTagRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Application.Features.VenueTags.Queries.GetVenueTags;

public class GetVenueTagsQueryHandler : IRequestHandler<GetVenueTagsQueryRequest, Result<List<ResultVenueTagDto>>>
{
    private readonly IVenueTagRepository _repository;
    private readonly IMapper _mapper;

    public GetVenueTagsQueryHandler(IVenueTagRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<ResultVenueTagDto>>> Handle(GetVenueTagsQueryRequest request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAll().ToListAsync(cancellationToken);
        var list = _mapper.Map<List<ResultVenueTagDto>>(entities);
        return Result<List<ResultVenueTagDto>>.SuccessResult(list);
    }
}

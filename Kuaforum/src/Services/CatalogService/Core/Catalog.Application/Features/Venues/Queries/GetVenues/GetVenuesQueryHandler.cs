using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.VenueDtos;
using Catalog.Application.Repositories.VenueRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Application.Features.Venues.Queries.GetVenues;

public class GetVenuesQueryHandler : IRequestHandler<GetVenuesQueryRequest, Result<List<VenueDto>>>
{
    private readonly IVenueRepository _repository;
    private readonly IMapper _mapper;

    public GetVenuesQueryHandler(IVenueRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<VenueDto>>> Handle(GetVenuesQueryRequest request, CancellationToken cancellationToken)
    {
        var venues = await _repository.GetAll(false).ToListAsync(cancellationToken);
        var dtoList = _mapper.Map<List<VenueDto>>(venues);
        return Result<List<VenueDto>>.SuccessResult(dtoList);
    }
}

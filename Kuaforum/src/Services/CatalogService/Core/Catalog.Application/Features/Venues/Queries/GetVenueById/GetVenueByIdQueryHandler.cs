using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.VenueDtos;
using Catalog.Application.Repositories.VenueRepository;
using MediatR;

namespace Catalog.Application.Features.Venues.Queries.GetVenueById;

public class GetVenueByIdQueryHandler : IRequestHandler<GetVenueByIdQueryRequest, Result<VenueDto>>
{
    private readonly IVenueRepository _repository;
    private readonly IMapper _mapper;

    public GetVenueByIdQueryHandler(IVenueRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<VenueDto>> Handle(GetVenueByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var venue = await _repository.GetByIdAsync(request.Id, false);
        if (venue == null)
            return Result<VenueDto>.FailureResult("Kayıt bulunamadı.");

        var dto = _mapper.Map<VenueDto>(venue);
        return Result<VenueDto>.SuccessResult(dto);
    }
}

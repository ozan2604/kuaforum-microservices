using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.VenueDtos;
using Catalog.Application.Repositories.VenueRepository;
using MediatR;

namespace Catalog.Application.Features.Venues.Queries.GetVenueById;

public class GetVenueByIdQueryHandler : IRequestHandler<GetVenueByIdQueryRequest, Result<ResultVenueDto>>
{
    private readonly IVenueRepository _repository;
    private readonly IMapper _mapper;

    public GetVenueByIdQueryHandler(IVenueRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<ResultVenueDto>> Handle(GetVenueByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var venue = await _repository.GetByIdAsync(request.Id, false);
        if (venue == null)
            return Result<ResultVenueDto>.FailureResult("Kayıt bulunamadı.");

        var dto = _mapper.Map<ResultVenueDto>(venue);
        return Result<ResultVenueDto>.SuccessResult(dto);
    }
}

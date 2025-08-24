using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.VenuePhotoDtos;
using Catalog.Application.Repositories.VenuePhotoRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Application.Features.VenuePhotos.Queries.GetVenuePhotos;

public class GetVenuePhotosQueryHandler : IRequestHandler<GetVenuePhotosQueryRequest, Result<List<ResultVenuePhotoDto>>>
{
    private readonly IVenuePhotoRepository _repository;
    private readonly IMapper _mapper;

    public GetVenuePhotosQueryHandler(IVenuePhotoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<ResultVenuePhotoDto>>> Handle(GetVenuePhotosQueryRequest request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAll(false).ToListAsync(cancellationToken);
        var dtoList = _mapper.Map<List<ResultVenuePhotoDto>>(entities);
        return Result<List<ResultVenuePhotoDto>>.SuccessResult(dtoList);
    }
}

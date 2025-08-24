using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.ServicePhotoDtos;
using Catalog.Application.Repositories.ServicePhotoRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Application.Features.ServicePhotos.Queries.GetServicePhotos;

public class GetServicePhotosQueryHandler : IRequestHandler<GetServicePhotosQueryRequest, Result<List<ResultServicePhotoDto>>>
{
    private readonly IServicePhotoRepository _repository;
    private readonly IMapper _mapper;

    public GetServicePhotosQueryHandler(IServicePhotoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<ResultServicePhotoDto>>> Handle(GetServicePhotosQueryRequest request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAll(false).ToListAsync(cancellationToken);
        var dtoList = _mapper.Map<List<ResultServicePhotoDto>>(entities);
        return Result<List<ResultServicePhotoDto>>.SuccessResult(dtoList);
    }
}

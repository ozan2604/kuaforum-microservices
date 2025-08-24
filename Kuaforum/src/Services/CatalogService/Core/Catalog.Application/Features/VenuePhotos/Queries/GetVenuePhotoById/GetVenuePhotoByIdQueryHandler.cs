using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.VenuePhotoDtos;
using Catalog.Application.Repositories.VenuePhotoRepository;
using MediatR;

namespace Catalog.Application.Features.VenuePhotos.Queries.GetVenuePhotoById;

public class GetVenuePhotoByIdQueryHandler : IRequestHandler<GetVenuePhotoByIdQueryRequest, Result<ResultVenuePhotoDto>>
{
    private readonly IVenuePhotoRepository _repository;
    private readonly IMapper _mapper;

    public GetVenuePhotoByIdQueryHandler(IVenuePhotoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<ResultVenuePhotoDto>> Handle(GetVenuePhotoByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, false);
        if (entity == null)
            return Result<ResultVenuePhotoDto>.FailureResult("Kayıt bulunamadı.");

        var dto = _mapper.Map<ResultVenuePhotoDto>(entity);
        return Result<ResultVenuePhotoDto>.SuccessResult(dto);
    }
}

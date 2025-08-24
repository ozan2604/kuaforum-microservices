using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.ServicePhotoDtos;
using Catalog.Application.Repositories.ServicePhotoRepository;
using MediatR;

namespace Catalog.Application.Features.ServicePhotos.Queries.GetServicePhotoById;

public class GetServicePhotoByIdQueryHandler : IRequestHandler<GetServicePhotoByIdQueryRequest, Result<ResultServicePhotoDto>>
{
    private readonly IServicePhotoRepository _repository;
    private readonly IMapper _mapper;

    public GetServicePhotoByIdQueryHandler(IServicePhotoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<ResultServicePhotoDto>> Handle(GetServicePhotoByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, false);
        if (entity == null)
            return Result<ResultServicePhotoDto>.FailureResult("Kayıt bulunamadı.");

        var dto = _mapper.Map<ResultServicePhotoDto>(entity);
        return Result<ResultServicePhotoDto>.SuccessResult(dto);
    }
}

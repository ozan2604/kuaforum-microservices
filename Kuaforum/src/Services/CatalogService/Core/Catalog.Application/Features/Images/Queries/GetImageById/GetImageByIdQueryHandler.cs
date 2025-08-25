using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.ImageDtos;
using Catalog.Application.Repositories.ImageRepository;
using MediatR;

namespace Catalog.Application.Features.Images.Queries.GetImageById;

public class GetImageByIdQueryHandler : IRequestHandler<GetImageByIdQueryRequest, Result<ResultImageDto>>
{
    private readonly IImageRepository _repository;
    private readonly IMapper _mapper;

    public GetImageByIdQueryHandler(IImageRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<ResultImageDto>> Handle(GetImageByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, false);
        if (entity == null)
            return Result<ResultImageDto>.FailureResult("Kayıt bulunamadı.");

        var dto = _mapper.Map<ResultImageDto>(entity);
        return Result<ResultImageDto>.SuccessResult(dto);
    }
}

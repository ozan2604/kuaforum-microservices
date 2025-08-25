using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.ImageDtos;
using Catalog.Application.Repositories.ImageRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Application.Features.Images.Queries.GetImages;

public class GetImagesQueryHandler : IRequestHandler<GetImagesQueryRequest, Result<List<ResultImageDto>>>
{
    private readonly IImageRepository _repository;
    private readonly IMapper _mapper;

    public GetImagesQueryHandler(IImageRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<ResultImageDto>>> Handle(GetImagesQueryRequest request, CancellationToken cancellationToken)
    {
        var images = await _repository.GetAll(false).ToListAsync(cancellationToken);
        var dtoList = _mapper.Map<List<ResultImageDto>>(images);
        return Result<List<ResultImageDto>>.SuccessResult(dtoList);
    }
}

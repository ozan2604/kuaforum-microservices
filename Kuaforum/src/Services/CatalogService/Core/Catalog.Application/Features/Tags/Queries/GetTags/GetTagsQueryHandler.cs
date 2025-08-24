using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.TagDtos;
using Catalog.Application.Repositories.TagRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Application.Features.Tags.Queries.GetTags;

public class GetTagsQueryHandler : IRequestHandler<GetTagsQueryRequest, Result<List<ResultTagDto>>>
{
    private readonly ITagRepository _repository;
    private readonly IMapper _mapper;

    public GetTagsQueryHandler(ITagRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<ResultTagDto>>> Handle(GetTagsQueryRequest request, CancellationToken cancellationToken)
    {
        var tags = await _repository.GetAll(false).ToListAsync(cancellationToken);
        var dtoList = _mapper.Map<List<ResultTagDto>>(tags);
        return Result<List<ResultTagDto>>.SuccessResult(dtoList);
    }
}

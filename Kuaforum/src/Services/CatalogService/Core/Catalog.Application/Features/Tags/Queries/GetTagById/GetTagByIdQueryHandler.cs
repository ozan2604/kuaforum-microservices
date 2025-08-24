using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.TagDtos;
using Catalog.Application.Repositories.TagRepository;
using MediatR;

namespace Catalog.Application.Features.Tags.Queries.GetTagById;

public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQueryRequest, Result<ResultTagDto>>
{
    private readonly ITagRepository _repository;
    private readonly IMapper _mapper;

    public GetTagByIdQueryHandler(ITagRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<ResultTagDto>> Handle(GetTagByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var tag = await _repository.GetByIdAsync(request.Id, false);
        if (tag == null)
            return Result<ResultTagDto>.FailureResult("Kayıt bulunamadı.");

        var dto = _mapper.Map<ResultTagDto>(tag);
        return Result<ResultTagDto>.SuccessResult(dto);
    }
}

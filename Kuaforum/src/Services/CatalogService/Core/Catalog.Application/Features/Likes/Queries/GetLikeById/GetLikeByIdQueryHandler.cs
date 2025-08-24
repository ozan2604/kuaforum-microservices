using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.LikeDtos;
using Catalog.Application.Repositories.LikeRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Application.Features.Likes.Queries.GetLikeById;

public class GetLikeByIdQueryHandler : IRequestHandler<GetLikeByIdQueryRequest, Result<ResultLikeDto>>
{
    private readonly ILikeRepository _repository;
    private readonly IMapper _mapper;

    public GetLikeByIdQueryHandler(ILikeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<ResultLikeDto>> Handle(GetLikeByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var like = await _repository.GetByIdAsync(request.Id);
        if (like == null) return Result<ResultLikeDto>.FailureResult("Bulunamadı.");
        var dto = _mapper.Map<ResultLikeDto>(like);
        return Result<ResultLikeDto>.SuccessResult(dto);
    }
}

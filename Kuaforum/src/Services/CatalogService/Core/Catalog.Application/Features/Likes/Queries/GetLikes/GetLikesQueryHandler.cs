using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.LikeDtos;
using Catalog.Application.Repositories.LikeRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Application.Features.Likes.Queries.GetLikes;

public class GetLikesQueryHandler : IRequestHandler<GetLikesQueryRequest, Result<List<ResultLikeDto>>>
{
    private readonly ILikeRepository _repository;
    private readonly IMapper _mapper;

    public GetLikesQueryHandler(ILikeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<ResultLikeDto>>> Handle(GetLikesQueryRequest request, CancellationToken cancellationToken)
    {
        var likes = await _repository.GetAll(false).ToListAsync(cancellationToken);
        var dtoList = _mapper.Map<List<ResultLikeDto>>(likes);
        return Result<List<ResultLikeDto>>.SuccessResult(dtoList);
    }
}

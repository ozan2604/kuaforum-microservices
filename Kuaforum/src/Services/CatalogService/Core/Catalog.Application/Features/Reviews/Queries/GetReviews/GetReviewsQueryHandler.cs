using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.ReviewDtos;
using Catalog.Application.Repositories.ReviewRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Application.Features.Reviews.Queries.GetReviews;

public class GetReviewsQueryHandler : IRequestHandler<GetReviewsQueryRequest, Result<List<ResultReviewDto>>>
{
    private readonly IReviewRepository _repository;
    private readonly IMapper _mapper;

    public GetReviewsQueryHandler(IReviewRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<ResultReviewDto>>> Handle(GetReviewsQueryRequest request, CancellationToken cancellationToken)
    {
        var reviews = await _repository.GetAll(false).ToListAsync(cancellationToken);
        var dtoList = _mapper.Map<List<ResultReviewDto>>(reviews);
        return Result<List<ResultReviewDto>>.SuccessResult(dtoList);
    }
}

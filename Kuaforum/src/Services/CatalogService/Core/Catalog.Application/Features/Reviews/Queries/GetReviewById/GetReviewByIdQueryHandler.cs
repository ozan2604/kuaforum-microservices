using Application.Results;
using AutoMapper;
using Catalog.Application.Dtos.ReviewDtos;
using Catalog.Application.Repositories.ReviewRepository;
using MediatR;

namespace Catalog.Application.Features.Reviews.Queries.GetReviewById;

public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQueryRequest, Result<ResultReviewDto>>
{
    private readonly IReviewRepository _repository;
    private readonly IMapper _mapper;

    public GetReviewByIdQueryHandler(IReviewRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<ResultReviewDto>> Handle(GetReviewByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var review = await _repository.GetByIdAsync(request.Id, false);
        if (review == null)
            return Result<ResultReviewDto>.FailureResult("Kayıt bulunamadı.");

        var dto = _mapper.Map<ResultReviewDto>(review);
        return Result<ResultReviewDto>.SuccessResult(dto);
    }
}

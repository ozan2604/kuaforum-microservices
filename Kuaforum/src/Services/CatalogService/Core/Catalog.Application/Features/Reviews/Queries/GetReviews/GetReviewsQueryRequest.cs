using Application.Results;
using Catalog.Application.Dtos.ReviewDtos;
using MediatR;

namespace Catalog.Application.Features.Reviews.Queries.GetReviews;

public class GetReviewsQueryRequest : IRequest<Result<List<ResultReviewDto>>>
{
}

using Application.Results;
using Catalog.Application.Dtos.ReviewDtos;
using MediatR;

namespace Catalog.Application.Features.Reviews.Queries.GetReviewById;

public class GetReviewByIdQueryRequest : IRequest<Result<ResultReviewDto>>
{
    public Guid Id { get; set; }
}

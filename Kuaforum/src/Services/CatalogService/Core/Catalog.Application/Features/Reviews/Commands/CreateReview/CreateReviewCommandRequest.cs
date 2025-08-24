using Catalog.Application.Dtos.ReviewDtos;
using Application.Results;
using MediatR;

namespace Catalog.Application.Features.Reviews.Commands.CreateReview;

public class CreateReviewCommandRequest : IRequest<Result<Guid>>
{
    public required CreateReviewDto Review { get; set; }
}

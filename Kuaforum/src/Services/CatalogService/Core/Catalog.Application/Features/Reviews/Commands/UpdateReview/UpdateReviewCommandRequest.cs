using Catalog.Application.Dtos.ReviewDtos;
using Application.Results;
using MediatR;

namespace Catalog.Application.Features.Reviews.Commands.UpdateReview;

public class UpdateReviewCommandRequest : IRequest<Result>
{
    public required UpdateReviewDto Review { get; set; }
}

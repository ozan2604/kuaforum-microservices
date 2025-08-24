using Application.Results;
using MediatR;

namespace Catalog.Application.Features.Reviews.Commands.DeleteReview;

public class DeleteReviewCommandRequest : IRequest<Result>
{
    public Guid Id { get; set; }
}

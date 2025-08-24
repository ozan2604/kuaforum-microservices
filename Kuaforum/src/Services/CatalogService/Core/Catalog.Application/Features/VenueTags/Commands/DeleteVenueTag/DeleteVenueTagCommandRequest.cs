using Application.Results;
using MediatR;

namespace Catalog.Application.Features.VenueTags.Commands.DeleteVenueTag;

public class DeleteVenueTagCommandRequest : IRequest<Result>
{
    public Guid VenueId { get; set; }
    public Guid TagId { get; set; }
}

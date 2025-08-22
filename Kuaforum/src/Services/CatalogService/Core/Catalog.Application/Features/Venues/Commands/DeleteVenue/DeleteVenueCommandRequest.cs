using Application.Results;
using MediatR;

namespace Catalog.Application.Features.Venues.Commands.DeleteVenue;

public class DeleteVenueCommandRequest : IRequest<Result>
{
    public Guid Id { get; set; }
}

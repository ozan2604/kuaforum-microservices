using Catalog.Application.Dtos.VenueDtos;
using Application.Results;
using MediatR;

namespace Catalog.Application.Features.Venues.Commands.UpdateVenue;

public class UpdateVenueCommandRequest : IRequest<Result>
{
    public required VenueDto Venue { get; set; }
}

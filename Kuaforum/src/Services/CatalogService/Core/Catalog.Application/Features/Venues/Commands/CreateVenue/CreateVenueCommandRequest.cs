using Catalog.Application.Dtos.VenueDtos;
using Application.Results;
using MediatR;

namespace Catalog.Application.Features.Venues.Commands.CreateVenue;

public class CreateVenueCommandRequest : IRequest<Result<Guid>>
{
    public required CreateVenueDto Venue { get; set; }
}

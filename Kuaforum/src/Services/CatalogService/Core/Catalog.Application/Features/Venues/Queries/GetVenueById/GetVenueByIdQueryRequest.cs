using Application.Results;
using Catalog.Application.Dtos.VenueDtos;
using MediatR;

namespace Catalog.Application.Features.Venues.Queries.GetVenueById;

public class GetVenueByIdQueryRequest : IRequest<Result<VenueDto>>
{
    public Guid Id { get; set; }
}

using Application.Results;
using Catalog.Application.Dtos.VenueTagDtos;
using MediatR;

namespace Catalog.Application.Features.VenueTags.Queries.GetVenueTagById;

public class GetVenueTagByIdQueryRequest : IRequest<Result<VenueTagDto>>
{
    public Guid VenueId { get; set; }
    public Guid TagId { get; set; }
}

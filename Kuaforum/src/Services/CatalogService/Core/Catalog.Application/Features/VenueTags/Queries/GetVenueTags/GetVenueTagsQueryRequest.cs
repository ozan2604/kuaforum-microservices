using Application.Results;
using Catalog.Application.Dtos.VenueTagDtos;
using MediatR;

namespace Catalog.Application.Features.VenueTags.Queries.GetVenueTags;

public class GetVenueTagsQueryRequest : IRequest<Result<List<ResultVenueTagDto>>>
{
}

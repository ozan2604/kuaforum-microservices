using Application.Results;
using Catalog.Application.Dtos.VenueDtos;
using MediatR;

namespace Catalog.Application.Features.Venues.Queries.GetVenues;

public class GetVenuesQueryRequest : IRequest<Result<List<ResultVenueDto>>>
{
}

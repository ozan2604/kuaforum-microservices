using Application.Results;
using Catalog.Application.Dtos.ServiceDtos;
using MediatR;

namespace Catalog.Application.Features.Services.Queries.GetServices;

public class GetServicesQueryRequest : IRequest<Result<List<ResultServiceDto>>>
{
}

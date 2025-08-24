using Application.Results;
using Catalog.Application.Dtos.ServiceDtos;
using MediatR;

namespace Catalog.Application.Features.Services.Queries.GetServiceById;

public class GetServiceByIdQueryRequest : IRequest<Result<ResultServiceDto>>
{
    public Guid Id { get; set; }
}

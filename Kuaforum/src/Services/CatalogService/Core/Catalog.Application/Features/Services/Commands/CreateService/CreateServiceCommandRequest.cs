using Catalog.Application.Dtos.ServiceDtos;
using Application.Results;
using MediatR;

namespace Catalog.Application.Features.Services.Commands.CreateService;

public class CreateServiceCommandRequest : IRequest<Result<Guid>>
{
    public required CreateServiceDto Service { get; set; }
}

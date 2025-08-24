using Catalog.Application.Dtos.ServiceDtos;
using Application.Results;
using MediatR;

namespace Catalog.Application.Features.Services.Commands.UpdateService;

public class UpdateServiceCommandRequest : IRequest<Result>
{
    public required UpdateServiceDto Service { get; set; }
}

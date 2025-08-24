using Application.Results;
using MediatR;

namespace Catalog.Application.Features.Services.Commands.DeleteService;

public class DeleteServiceCommandRequest : IRequest<Result>
{
    public Guid Id { get; set; }
}

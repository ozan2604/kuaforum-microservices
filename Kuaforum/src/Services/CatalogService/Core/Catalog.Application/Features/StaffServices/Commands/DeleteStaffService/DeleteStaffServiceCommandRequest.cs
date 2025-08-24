using Application.Results;
using MediatR;

namespace Catalog.Application.Features.StaffServices.Commands.DeleteStaffService;

public class DeleteStaffServiceCommandRequest : IRequest<Result>
{
    public Guid Id { get; set; }
}

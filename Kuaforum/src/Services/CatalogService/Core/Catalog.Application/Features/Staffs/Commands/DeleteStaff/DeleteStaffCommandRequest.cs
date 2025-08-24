using Application.Results;
using MediatR;

namespace Catalog.Application.Features.Staffs.Commands.DeleteStaff;

public class DeleteStaffCommandRequest : IRequest<Result>
{
    public Guid Id { get; set; }
}

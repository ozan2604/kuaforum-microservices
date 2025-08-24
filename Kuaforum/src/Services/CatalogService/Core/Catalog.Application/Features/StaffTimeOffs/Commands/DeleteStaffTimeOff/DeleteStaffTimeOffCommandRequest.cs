using Application.Results;
using MediatR;

namespace Catalog.Application.Features.StaffTimeOffs.Commands.DeleteStaffTimeOff;

public class DeleteStaffTimeOffCommandRequest : IRequest<Result>
{
    public Guid Id { get; set; }
}

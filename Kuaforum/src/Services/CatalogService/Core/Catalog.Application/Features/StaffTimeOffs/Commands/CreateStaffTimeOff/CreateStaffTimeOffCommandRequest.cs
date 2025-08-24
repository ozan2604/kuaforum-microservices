using Application.Results;
using Catalog.Application.Dtos.StaffTimeOffDtos;
using MediatR;

namespace Catalog.Application.Features.StaffTimeOffs.Commands.CreateStaffTimeOff;

public class CreateStaffTimeOffCommandRequest : IRequest<Result<Guid>>
{
    public required CreateStaffTimeOffDto TimeOff { get; set; }
}

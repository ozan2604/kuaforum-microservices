using Application.Results;
using Catalog.Application.Dtos.StaffTimeOffDtos;
using MediatR;

namespace Catalog.Application.Features.StaffTimeOffs.Commands.UpdateStaffTimeOff;

public class UpdateStaffTimeOffCommandRequest : IRequest<Result>
{
    public required UpdateStaffTimeOffDto TimeOff { get; set; }
}

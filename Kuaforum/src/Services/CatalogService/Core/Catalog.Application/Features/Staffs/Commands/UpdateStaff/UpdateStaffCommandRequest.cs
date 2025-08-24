using Catalog.Application.Dtos.StaffDtos;
using Application.Results;
using MediatR;

namespace Catalog.Application.Features.Staffs.Commands.UpdateStaff;

public class UpdateStaffCommandRequest : IRequest<Result>
{
    public required UpdateStaffDto Staff { get; set; }
}

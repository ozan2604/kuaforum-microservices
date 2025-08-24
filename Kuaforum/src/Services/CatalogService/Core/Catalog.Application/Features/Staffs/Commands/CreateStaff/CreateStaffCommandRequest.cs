using Catalog.Application.Dtos.StaffDtos;
using Application.Results;
using MediatR;

namespace Catalog.Application.Features.Staffs.Commands.CreateStaff;

public class CreateStaffCommandRequest : IRequest<Result<Guid>>
{
    public required CreateStaffDto Staff { get; set; }
}

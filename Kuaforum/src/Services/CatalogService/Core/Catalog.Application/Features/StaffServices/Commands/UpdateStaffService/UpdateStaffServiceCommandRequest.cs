using Application.Results;
using Catalog.Application.Dtos.StaffServiceDtos;
using MediatR;

namespace Catalog.Application.Features.StaffServices.Commands.UpdateStaffService;

public class UpdateStaffServiceCommandRequest : IRequest<Result>
{
    public required UpdateStaffServiceDto StaffService { get; set; }
}

using Application.Results;
using Catalog.Application.Dtos.StaffServiceDtos;
using MediatR;

namespace Catalog.Application.Features.StaffServices.Commands.CreateStaffService;

public class CreateStaffServiceCommandRequest : IRequest<Result<Guid>>
{
    public required CreateStaffServiceDto StaffService { get; set; }
}

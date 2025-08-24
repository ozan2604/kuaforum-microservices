using Catalog.Application.Dtos.StaffDtos;
using Application.Results;
using MediatR;

namespace Catalog.Application.Features.Staffs.Queries.GetStaffById;

public class GetStaffByIdQueryRequest : IRequest<Result<ResultStaffDto>>
{
    public Guid Id { get; set; }
}

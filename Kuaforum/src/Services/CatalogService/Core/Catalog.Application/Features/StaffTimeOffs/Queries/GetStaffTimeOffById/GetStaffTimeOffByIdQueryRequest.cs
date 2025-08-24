using Application.Results;
using Catalog.Application.Dtos.StaffTimeOffDtos;
using MediatR;

namespace Catalog.Application.Features.StaffTimeOffs.Queries.GetStaffTimeOffById;

public class GetStaffTimeOffByIdQueryRequest : IRequest<Result<ResultStaffTimeOffDto>>
{
    public Guid Id { get; set; }
}

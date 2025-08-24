using Application.Results;
using Catalog.Application.Dtos.StaffTimeOffDtos;
using MediatR;

namespace Catalog.Application.Features.StaffTimeOffs.Queries.GetStaffTimeOffs;

public class GetStaffTimeOffsQueryRequest : IRequest<Result<List<ResultStaffTimeOffDto>>>
{
}

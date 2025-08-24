using Application.Results;
using MediatR;
using Catalog.Application.Dtos.StaffDtos;

namespace Catalog.Application.Features.Staffs.Queries.GetStaffs;

public class GetStaffsQueryRequest : IRequest<Result<List<ResultStaffDto>>>
{
}

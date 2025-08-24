using Application.Results;
using Catalog.Application.Dtos.StaffServiceDtos;
using MediatR;

namespace Catalog.Application.Features.StaffServices.Queries.GetStaffServices;

public class GetStaffServicesQueryRequest : IRequest<Result<List<ResultStaffServiceDto>>>
{
}

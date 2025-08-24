using Application.Results;
using Catalog.Application.Dtos.StaffServiceDtos;
using MediatR;

namespace Catalog.Application.Features.StaffServices.Queries.GetStaffServiceById;

public class GetStaffServiceByIdQueryRequest : IRequest<Result<ResultStaffServiceDto>>
{
    public Guid Id { get; set; }
}

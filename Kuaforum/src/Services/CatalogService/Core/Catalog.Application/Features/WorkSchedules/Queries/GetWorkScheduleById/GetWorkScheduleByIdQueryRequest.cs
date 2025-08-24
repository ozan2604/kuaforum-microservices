using Application.Results;
using Catalog.Application.Dtos.WorkScheduleDtos;
using MediatR;

namespace Catalog.Application.Features.WorkSchedules.Queries.GetWorkScheduleById;

public class GetWorkScheduleByIdQueryRequest : IRequest<Result<ResultWorkScheduleDto>>
{
    public Guid Id { get; set; }
}

using Application.Results;
using Catalog.Application.Dtos.WorkScheduleDtos;
using MediatR;

namespace Catalog.Application.Features.WorkSchedules.Queries.GetWorkSchedules;

public class GetWorkSchedulesQueryRequest : IRequest<Result<List<ResultWorkScheduleDto>>>
{
}

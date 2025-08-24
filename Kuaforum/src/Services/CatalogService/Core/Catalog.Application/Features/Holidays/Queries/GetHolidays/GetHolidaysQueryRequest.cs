using Application.Results;
using Catalog.Application.Dtos.HolidayDtos;
using MediatR;

namespace Catalog.Application.Features.Holidays.Queries.GetHolidays;

public class GetHolidaysQueryRequest : IRequest<Result<List<ResultHolidayDto>>>
{
}

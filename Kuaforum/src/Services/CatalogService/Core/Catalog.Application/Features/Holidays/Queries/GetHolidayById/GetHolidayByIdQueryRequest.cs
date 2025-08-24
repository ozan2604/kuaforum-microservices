using Application.Results;
using Catalog.Application.Dtos.HolidayDtos;
using MediatR;

namespace Catalog.Application.Features.Holidays.Queries.GetHolidayById;

public class GetHolidayByIdQueryRequest : IRequest<Result<ResultHolidayDto>>
{
    public Guid Id { get; set; }
}

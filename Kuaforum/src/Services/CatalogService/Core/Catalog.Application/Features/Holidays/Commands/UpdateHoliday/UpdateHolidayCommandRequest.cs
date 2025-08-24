using Application.Results;
using Catalog.Application.Dtos.HolidayDtos;
using MediatR;

namespace Catalog.Application.Features.Holidays.Commands.UpdateHoliday;

public class UpdateHolidayCommandRequest : IRequest<Result<Guid>>
{
    public required UpdateHolidayDto Holiday { get; set; }
}

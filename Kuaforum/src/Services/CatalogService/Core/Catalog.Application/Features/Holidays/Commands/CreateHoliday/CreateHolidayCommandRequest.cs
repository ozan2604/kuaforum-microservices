using Application.Results;
using Catalog.Application.Dtos.HolidayDtos;
using MediatR;

namespace Catalog.Application.Features.Holidays.Commands.CreateHoliday;

public class CreateHolidayCommandRequest : IRequest<Result<Guid>>
{
    public required CreateHolidayDto Holiday { get; set; }
}

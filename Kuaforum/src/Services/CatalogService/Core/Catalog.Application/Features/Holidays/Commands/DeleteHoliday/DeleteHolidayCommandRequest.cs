using Application.Results;
using MediatR;

namespace Catalog.Application.Features.Holidays.Commands.DeleteHoliday;

public class DeleteHolidayCommandRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}

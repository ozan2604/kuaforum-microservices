using Application.Results;
using MediatR;

namespace Catalog.Application.Features.WorkSchedules.Commands.DeleteWorkSchedule;

public class DeleteWorkScheduleCommandRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}

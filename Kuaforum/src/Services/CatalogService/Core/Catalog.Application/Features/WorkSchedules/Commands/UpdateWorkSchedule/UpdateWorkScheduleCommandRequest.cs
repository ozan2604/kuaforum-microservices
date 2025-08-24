using Application.Results;
using Catalog.Application.Dtos.WorkScheduleDtos;
using MediatR;

namespace Catalog.Application.Features.WorkSchedules.Commands.UpdateWorkSchedule;

public class UpdateWorkScheduleCommandRequest : IRequest<Result<Guid>>
{
    public required UpdateWorkScheduleDto WorkSchedule { get; set; }
}

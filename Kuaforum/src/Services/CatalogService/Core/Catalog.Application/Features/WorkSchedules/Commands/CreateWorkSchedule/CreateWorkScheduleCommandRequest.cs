using Application.Results;
using Catalog.Application.Dtos.WorkScheduleDtos;
using MediatR;

namespace Catalog.Application.Features.WorkSchedules.Commands.CreateWorkSchedule;

public class CreateWorkScheduleCommandRequest : IRequest<Result<Guid>>
{
    public required CreateWorkScheduleDto WorkSchedule { get; set; }
}

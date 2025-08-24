using Appointment.Application.Dtos.AppointmentHistoryDtos;
using Appointment.Application.Results;
using MediatR;

namespace Appointment.Application.Features.AppointmentHistories.Queries.GetAppointmentHistoryById;

public class GetAppointmentHistoryByIdQueryRequest : IRequest<Result<ResultAppointmentHistoryDto>>
{
    public Guid Id { get; set; }
}

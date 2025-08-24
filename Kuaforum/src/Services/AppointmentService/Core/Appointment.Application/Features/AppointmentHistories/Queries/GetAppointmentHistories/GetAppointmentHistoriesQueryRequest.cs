using Appointment.Application.Dtos.AppointmentHistoryDtos;
using Appointment.Application.Results;
using MediatR;

namespace Appointment.Application.Features.AppointmentHistories.Queries.GetAppointmentHistories;

public class GetAppointmentHistoriesQueryRequest : IRequest<Result<List<ResultAppointmentHistoryDto>>>
{
}

using Appointment.Application.Dtos.AppointmentDtos;
using Appointment.Application.Results;
using MediatR;

namespace Appointment.Application.Features.Appointments.Queries.GetAppointments;

public class GetAppointmentsQueryRequest : IRequest<Result<List<ResultAppointmentDto>>>
{
}

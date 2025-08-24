using Appointment.Application.Dtos.AppointmentDtos;
using Appointment.Application.Results;
using MediatR;

namespace Appointment.Application.Features.Appointments.Queries.GetAppointmentById;

public class GetAppointmentByIdQueryRequest : IRequest<Result<ResultAppointmentDto>>
{
    public Guid Id { get; set; }
}

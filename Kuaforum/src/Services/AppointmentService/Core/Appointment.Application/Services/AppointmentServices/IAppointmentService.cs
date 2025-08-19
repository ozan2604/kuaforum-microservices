using Appointment.Application.Dtos.AppointmentDtos;
using Appointment.Application.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.Services.AppointmentServices
{
    public interface IAppointmentService : IGenericService<AppointmentDto, CreateAppointmentDto, UpdateAppointmentDto>
    {
        Task<Result<CreateAppointmentResult>> CreateAppointmentAsync(CreateAppointmentDto dto, CancellationToken cancellationToken);
    }
}

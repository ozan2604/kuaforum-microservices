using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.Repositories.AppointmentRepositories
{
    public interface IAppointmentRepository : IGenericRepository<Appointment.Domain.Entities.Appointment>
    {
    }
}

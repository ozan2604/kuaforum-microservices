using Appointment.Application.Repositories.AppointmentRepositories;
using Appointment.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Persistence.Repositories.AppointmentRepositories
{
    public class AppointmentRepository : GenericRepository<Appointment.Domain.Entities.Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(AppointmentServiceDbContext context) : base(context)
        {
        }
    }
}

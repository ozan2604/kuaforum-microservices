using Appointment.Application.Repositories.AppointmentHistoryRepositories;
using Appointment.Domain.Entities;
using Appointment.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Persistence.Repositories.AppointmentHistoryRepositories
{
    public class AppointmentHistoryRepository : GenericRepository<AppointmentHistory>, IAppointmentHistoryRepository
    {
        public AppointmentHistoryRepository(AppointmentServiceDbContext context) : base(context)
        {
        }
    }
}

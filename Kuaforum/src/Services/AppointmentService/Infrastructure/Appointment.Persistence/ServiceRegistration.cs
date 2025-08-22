using Appointment.Application.Repositories.AppointmentRepositories;
using Appointment.Persistence.Contexts;
using Appointment.Persistence.Repositories.AppointmentRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddAppointmentPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppointmentServiceDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

            services.AddScoped<AppointmentServiceDbContext>();

            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        }
    }
}

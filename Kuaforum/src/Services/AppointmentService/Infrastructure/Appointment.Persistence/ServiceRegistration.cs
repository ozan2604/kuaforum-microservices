using Appointment.Application.Interfaces.Services;
using Appointment.Application.Repositories.AppointmentRepositories;
using Appointment.Persistence.Contexts;
using Appointment.Persistence.Repositories.AppointmentRepositories;
using Appointment.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Appointment.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddAppointmentPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppointmentServiceDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

            services.AddScoped<AppointmentServiceDbContext>();

            services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            services.AddHttpClient<ICatalogService, CatalogService>(client =>
            {
                client.BaseAddress = new Uri(configuration["ServiceUrls:Catalog"]);
            });
        }
    }
}

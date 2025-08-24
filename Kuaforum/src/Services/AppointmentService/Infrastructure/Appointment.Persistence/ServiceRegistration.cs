using Appointment.Application.Repositories.AppointmentHistoryRepositories;
using Appointment.Application.Repositories.AppointmentRepositories;
using Appointment.Application.Repositories.BookingRequestRepositories;
using Appointment.Persistence.Contexts;
using Appointment.Persistence.Repositories.AppointmentHistoryRepositories;
using Appointment.Persistence.Repositories.AppointmentRepositories;
using Appointment.Persistence.Repositories.BookingRequestRepositories;
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
            services.AddScoped<IAppointmentHistoryRepository, AppointmentHistoryRepository>();
            services.AddScoped<IBookingRequestRepository, BookingRequestRepository>();


        }
    }
}

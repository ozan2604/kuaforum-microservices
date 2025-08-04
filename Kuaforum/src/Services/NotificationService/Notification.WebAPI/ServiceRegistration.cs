using Notification.WebAPI.Interfaces;
using Notification.WebAPI.Services;

namespace Notification.WebAPI
{
    public static class ServiceRegistration
    {
        public static void AddNotificationServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}

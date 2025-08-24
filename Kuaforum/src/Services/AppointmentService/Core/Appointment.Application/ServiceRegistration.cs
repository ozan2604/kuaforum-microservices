using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Appointment.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddAppointmentApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}

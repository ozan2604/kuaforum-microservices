using Log.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddLogPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<LogServiceDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddScoped<LogServiceDbContext>();
        }
    }
}

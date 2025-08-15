using Catalog.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddLogPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<CatalogServiceDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddScoped<CatalogServiceDbContext>();
        }
    }
}

using Catalog.Application.Repositories;
using Catalog.Application.Repositories.VenueRepository;
using Catalog.Application.Services.CurrentUserServices;
using Catalog.Persistence.Contexts;
using Catalog.Persistence.Repositories;
using Catalog.Persistence.Repositories.VenueRepositories;
using Catalog.Persistence.Services.CurrentUserServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddCatalogPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<CatalogServiceDbContext>(options => options.UseNpgsql(Configuration.ConnectionString
             //   ,o => o.UseNetTopologySuite()
             ));
            
            services.AddScoped<CatalogServiceDbContext>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IVenueRepository, VenueRepository>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

        }
    }
}

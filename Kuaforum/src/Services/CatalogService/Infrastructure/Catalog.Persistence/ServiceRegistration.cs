using Catalog.Application.Repositories;
using Catalog.Application.Repositories.VenueRepository;
using Catalog.Application.Repositories.TagRepository;
using Catalog.Application.Repositories.ServiceRepository;
using Catalog.Application.Services.CurrentUserServices;
using Catalog.Persistence.Contexts;
using Catalog.Persistence.Repositories;
using Catalog.Persistence.Repositories.VenueRepositories;
using Catalog.Persistence.Repositories.TagRepositories;
using Catalog.Persistence.Repositories.ServiceRepositories;
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
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

        }
    }
}

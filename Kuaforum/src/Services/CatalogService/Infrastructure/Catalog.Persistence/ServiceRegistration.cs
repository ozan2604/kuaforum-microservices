using Catalog.Application.Repositories;
using Catalog.Application.Repositories.VenueRepository;
using Catalog.Application.Repositories.TagRepository;
using Catalog.Application.Repositories.VenueTagRepository;
using Catalog.Application.Repositories.ServiceRepository;
using Catalog.Application.Repositories.ImageRepository;
using Catalog.Application.Repositories.HolidayRepository;
using Catalog.Application.Repositories.LikeRepository;
using Catalog.Application.Repositories.ReviewRepository;
using Catalog.Application.Repositories.StaffRepository;
using Catalog.Application.Repositories.StaffTimeOffRepository;
using Catalog.Application.Repositories.WorkScheduleRepository;
using Catalog.Application.Services.CurrentUserServices;
using Catalog.Persistence.Contexts;
using Catalog.Persistence.Repositories;
using Catalog.Persistence.Repositories.VenueRepositories;
using Catalog.Persistence.Repositories.VenueTagRepositories;
using Catalog.Persistence.Repositories.TagRepositories;
using Catalog.Persistence.Repositories.ServiceRepositories;
using Catalog.Persistence.Repositories.ImageRepositories;
using Catalog.Persistence.Repositories.HolidayRepositories;
using Catalog.Persistence.Repositories.LikeRepositories;
using Catalog.Persistence.Repositories.ReviewRepositories;
using Catalog.Persistence.Repositories.StaffRepositories;
using Catalog.Persistence.Repositories.StaffTimeOffRepositories;
using Catalog.Persistence.Repositories.WorkScheduleRepositories;
using Catalog.Persistence.Services.CurrentUserServices;
using Microsoft.EntityFrameworkCore;
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
            services.AddScoped<IVenueTagRepository, VenueTagRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IHolidayRepository, HolidayRepository>();
            services.AddScoped<ILikeRepository, LikeRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IStaffTimeOffRepository, StaffTimeOffRepository>();
            services.AddScoped<IWorkScheduleRepository, WorkScheduleRepository>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

        }
    }
}

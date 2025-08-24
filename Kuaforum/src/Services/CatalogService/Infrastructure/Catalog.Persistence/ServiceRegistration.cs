using Catalog.Application.Repositories;
using Catalog.Application.Repositories.VenueRepository;
using Catalog.Application.Repositories.TagRepository;
using Catalog.Application.Repositories.ServiceRepository;
using Catalog.Application.Repositories.HolidayRepository;
using Catalog.Application.Repositories.LikeRepository;
using Catalog.Application.Repositories.ReviewRepository;
using Catalog.Application.Repositories.ServicePhotoRepository;
using Catalog.Application.Repositories.StaffRepository;
using Catalog.Application.Repositories.StaffSkillRepository;
using Catalog.Application.Repositories.StaffServiceRepository;
using Catalog.Application.Repositories.StaffTimeOffRepository;
using Catalog.Application.Repositories.VenuePhotoRepository;
using Catalog.Application.Repositories.WorkScheduleRepository;
using Catalog.Application.Services.CurrentUserServices;
using Catalog.Persistence.Contexts;
using Catalog.Persistence.Repositories;
using Catalog.Persistence.Repositories.VenueRepositories;
using Catalog.Persistence.Repositories.TagRepositories;
using Catalog.Persistence.Repositories.ServiceRepositories;
using Catalog.Persistence.Repositories.HolidayRepositories;
using Catalog.Persistence.Repositories.LikeRepositories;
using Catalog.Persistence.Repositories.ReviewRepositories;
using Catalog.Persistence.Repositories.ServicePhotoRepositories;
using Catalog.Persistence.Repositories.StaffRepositories;
using Catalog.Persistence.Repositories.StaffSkillRepositories;
using Catalog.Persistence.Repositories.StaffServiceRepositories;
using Catalog.Persistence.Repositories.StaffTimeOffRepositories;
using Catalog.Persistence.Repositories.VenuePhotoRepositories;
using Catalog.Persistence.Repositories.WorkScheduleRepositories;
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
            services.AddScoped<IHolidayRepository, HolidayRepository>();
            services.AddScoped<ILikeRepository, LikeRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IServicePhotoRepository, ServicePhotoRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IStaffSkillRepository, StaffSkillRepository>();
            services.AddScoped<IStaffServiceRepository, StaffServiceRepository>();
            services.AddScoped<IStaffTimeOffRepository, StaffTimeOffRepository>();
            services.AddScoped<IVenuePhotoRepository, VenuePhotoRepository>();
            services.AddScoped<IWorkScheduleRepository, WorkScheduleRepository>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

        }
    }
}

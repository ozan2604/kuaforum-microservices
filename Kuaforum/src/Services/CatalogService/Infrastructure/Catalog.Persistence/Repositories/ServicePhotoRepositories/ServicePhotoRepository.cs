using Catalog.Application.Repositories.ServicePhotoRepository;
using Catalog.Domain.Entities;
using Catalog.Persistence.Contexts;

namespace Catalog.Persistence.Repositories.ServicePhotoRepositories;

public class ServicePhotoRepository : GenericRepository<ServicePhoto>, IServicePhotoRepository
{
    public ServicePhotoRepository(CatalogServiceDbContext context) : base(context)
    {
    }
}

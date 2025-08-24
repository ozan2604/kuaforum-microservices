using Catalog.Application.Repositories.ServiceRepository;
using Catalog.Domain.Entities;
using Catalog.Persistence.Contexts;

namespace Catalog.Persistence.Repositories.ServiceRepositories
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository(CatalogServiceDbContext context) : base(context)
        {
        }
    }
}

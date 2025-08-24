using Catalog.Application.Repositories.StaffServiceRepository;
using Catalog.Domain.Entities;
using Catalog.Persistence.Contexts;

namespace Catalog.Persistence.Repositories.StaffServiceRepositories;

public class StaffServiceRepository : GenericRepository<StaffService>, IStaffServiceRepository
{
    public StaffServiceRepository(CatalogServiceDbContext context) : base(context)
    {
    }
}

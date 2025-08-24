using Catalog.Application.Repositories.StaffTimeOffRepository;
using Catalog.Domain.Entities;
using Catalog.Persistence.Contexts;

namespace Catalog.Persistence.Repositories.StaffTimeOffRepositories;

public class StaffTimeOffRepository : GenericRepository<StaffTimeOff>, IStaffTimeOffRepository
{
    public StaffTimeOffRepository(CatalogServiceDbContext context) : base(context)
    {
    }
}

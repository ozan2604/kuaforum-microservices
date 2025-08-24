using Catalog.Application.Repositories.StaffRepository;
using Catalog.Domain.Entities;
using Catalog.Persistence.Contexts;

namespace Catalog.Persistence.Repositories.StaffRepositories;

public class StaffRepository : GenericRepository<Staff>, IStaffRepository
{
    public StaffRepository(CatalogServiceDbContext context) : base(context)
    {
    }
}

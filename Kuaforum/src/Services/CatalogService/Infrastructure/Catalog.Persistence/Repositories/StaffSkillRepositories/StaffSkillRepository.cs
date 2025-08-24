using Catalog.Application.Repositories.StaffSkillRepository;
using Catalog.Domain.Entities;
using Catalog.Persistence.Contexts;

namespace Catalog.Persistence.Repositories.StaffSkillRepositories;

public class StaffSkillRepository : GenericRepository<StaffSkill>, IStaffSkillRepository
{
    public StaffSkillRepository(CatalogServiceDbContext context) : base(context)
    {
    }
}

using Catalog.Application.Repositories.WorkScheduleRepository;
using Catalog.Domain.Entities;
using Catalog.Persistence.Contexts;

namespace Catalog.Persistence.Repositories.WorkScheduleRepositories;

public class WorkScheduleRepository : GenericRepository<WorkSchedule>, IWorkScheduleRepository
{
    public WorkScheduleRepository(CatalogServiceDbContext context) : base(context)
    {
    }
}

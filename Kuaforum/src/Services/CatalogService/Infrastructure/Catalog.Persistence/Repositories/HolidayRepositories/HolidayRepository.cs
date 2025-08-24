using Catalog.Application.Repositories.HolidayRepository;
using Catalog.Domain.Entities;
using Catalog.Persistence.Contexts;

namespace Catalog.Persistence.Repositories.HolidayRepositories;

public class HolidayRepository : GenericRepository<Holiday>, IHolidayRepository
{
    public HolidayRepository(CatalogServiceDbContext context) : base(context)
    {
    }
}

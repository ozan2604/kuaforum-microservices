using Catalog.Application.Repositories.LikeRepository;
using Catalog.Domain.Entities;
using Catalog.Persistence.Contexts;

namespace Catalog.Persistence.Repositories.LikeRepositories;

public class LikeRepository : GenericRepository<Like>, ILikeRepository
{
    public LikeRepository(CatalogServiceDbContext context) : base(context)
    {
    }
}

using Catalog.Application.Repositories.ReviewRepository;
using Catalog.Domain.Entities;
using Catalog.Persistence.Contexts;

namespace Catalog.Persistence.Repositories.ReviewRepositories;

public class ReviewRepository : GenericRepository<Review>, IReviewRepository
{
    public ReviewRepository(CatalogServiceDbContext context) : base(context)
    {
    }
}

using Catalog.Application.Repositories.ImageRepository;
using Catalog.Domain.Entities;
using Catalog.Persistence.Contexts;

namespace Catalog.Persistence.Repositories.ImageRepositories;

public class ImageRepository : GenericRepository<Image>, IImageRepository
{
    public ImageRepository(CatalogServiceDbContext context) : base(context)
    {
    }
}

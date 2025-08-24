using Catalog.Application.Repositories.VenuePhotoRepository;
using Catalog.Domain.Entities;
using Catalog.Persistence.Contexts;

namespace Catalog.Persistence.Repositories.VenuePhotoRepositories;

public class VenuePhotoRepository : GenericRepository<VenuePhoto>, IVenuePhotoRepository
{
    public VenuePhotoRepository(CatalogServiceDbContext context) : base(context)
    {
    }
}

using Catalog.Application.Repositories.VenueRepository;
using Catalog.Domain.Entities;
using Catalog.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Persistence.Repositories.VenueRepositories
{
    public class VenueRepository : GenericRepository<Venue>, IVenueRepository
    {
        public VenueRepository(CatalogServiceDbContext context) : base(context)
        {
        }
    }
}

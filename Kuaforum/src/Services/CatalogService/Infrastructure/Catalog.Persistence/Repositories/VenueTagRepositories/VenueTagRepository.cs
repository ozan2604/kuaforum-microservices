using System;

using Catalog.Application.Repositories.VenueTagRepository;
using Catalog.Domain.Entities;
using Catalog.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Catalog.Persistence.Repositories.VenueTagRepositories;

public class VenueTagRepository : GenericRepository<VenueTag>, IVenueTagRepository
{
    public VenueTagRepository(CatalogServiceDbContext context) : base(context)
    {
    }
}

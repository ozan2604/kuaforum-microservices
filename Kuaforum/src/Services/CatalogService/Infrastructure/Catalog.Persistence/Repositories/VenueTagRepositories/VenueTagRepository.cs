using System;

using Catalog.Application.Repositories.VenueTagRepository;
using Catalog.Domain.Entities;
using Catalog.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Catalog.Persistence.Repositories.VenueTagRepositories;

public class VenueTagRepository : IVenueTagRepository
{
    private readonly CatalogServiceDbContext _context;

    public VenueTagRepository(CatalogServiceDbContext context)
    {
        _context = context;
    }

    public DbSet<VenueTag> Table => _context.VenueTags;

    public IQueryable<VenueTag> GetAll() => Table.AsQueryable();

    public IQueryable<VenueTag> GetWhere(Expression<Func<VenueTag, bool>> method) =>
        Table.Where(method);

    public async Task<VenueTag?> GetByIdsAsync(Guid venueId, Guid tagId) =>
        await Table.FirstOrDefaultAsync(x => x.VenueId == venueId && x.TagId == tagId);

    public async Task<bool> AddAsync(VenueTag entity)
    {
        await Table.AddAsync(entity);
        return true;
    }

    public bool Remove(VenueTag entity)
    {
        Table.Remove(entity);
        return true;
    }

    public async Task<bool> RemoveByIdsAsync(Guid venueId, Guid tagId)
    {
        var entity = await GetByIdsAsync(venueId, tagId);
        if (entity == null)
            return false;
        Table.Remove(entity);
        return true;
    }

    public Task<int> SaveAsync() => _context.SaveChangesAsync();
}

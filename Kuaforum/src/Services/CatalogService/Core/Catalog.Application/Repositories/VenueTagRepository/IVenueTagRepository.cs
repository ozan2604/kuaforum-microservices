using System;

using Catalog.Domain.Entities;
using System.Linq;
using System.Linq.Expressions;

namespace Catalog.Application.Repositories.VenueTagRepository;

public interface IVenueTagRepository
{
    IQueryable<VenueTag> Table { get; }
    IQueryable<VenueTag> GetAll();
    IQueryable<VenueTag> GetWhere(Expression<Func<VenueTag, bool>> method);
    Task<VenueTag?> GetByIdsAsync(Guid venueId, Guid tagId);
    Task<bool> AddAsync(VenueTag entity);
    bool Remove(VenueTag entity);
    Task<bool> RemoveByIdsAsync(Guid venueId, Guid tagId);
    Task<int> SaveAsync();
}

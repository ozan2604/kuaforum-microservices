using Catalog.Application.Repositories.TagRepository;
using Catalog.Domain.Entities;
using Catalog.Persistence.Contexts;

namespace Catalog.Persistence.Repositories.TagRepositories
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(CatalogServiceDbContext context) : base(context)
        {
        }
    }
}

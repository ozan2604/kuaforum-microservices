using AutoMapper;
using Catalog.Application.Interfaces.Services.VenueServices;
using Catalog.Application.Repositories;
using Catalog.Application.Repositories.VenueRepository;
using Catalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Persistence.Services.VenueServices
{
    public class VenueService : GenericService<Venue, VenueDto>, IVenueService
    {
        public VenueService(IGenericRepository<Venue> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

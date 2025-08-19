using AutoMapper;
using Catalog.Application.Interfaces.Services.VenueServices;
using Catalog.Domain.Entities;

namespace Catalog.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VenueDto, Venue>().ReverseMap();
        }
    }
}

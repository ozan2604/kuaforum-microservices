using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Dtos.VenueDtos
{
    public class UpdateVenueDto : CreateVenueDto
    {
        public Guid Id { get; set; }
    }
}

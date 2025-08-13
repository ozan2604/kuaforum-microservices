using Appoinment.Domain.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appoinment.Domain.Entites
{
    public class VenueProjection : BaseEntity
    {
        public Guid VenueId { get; set; }
        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}

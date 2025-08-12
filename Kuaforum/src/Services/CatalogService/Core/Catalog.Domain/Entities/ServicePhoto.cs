using Catalog.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Entities
{
    public class ServicePhoto : BaseEntity
    {
        public required Guid ServiceId { get; set; }
        public Service? Service { get; set; }

        public required string Url { get; set; }
        public bool IsCover { get; set; } = false;
        public int SortOrder { get; set; } = 0;
    }
}

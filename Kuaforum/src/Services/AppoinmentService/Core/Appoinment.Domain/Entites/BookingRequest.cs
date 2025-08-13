using Appoinment.Domain.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appoinment.Domain.Entites
{
    public class BookingRequest : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public string IdempotencyKey { get; set; } = null!; // client GUID
        public DateTime ConsumedAtUtc { get; set; } = DateTime.UtcNow;
    }
}

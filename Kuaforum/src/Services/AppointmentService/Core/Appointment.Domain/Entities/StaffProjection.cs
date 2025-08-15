using Appointment.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Entities
{
    public class StaffProjection : BaseEntity
    {
        public Guid StaffId { get; set; }
        public Guid VenueId { get; set; }
        public string FullName { get; set; } = null!;
        public bool IsActive { get; set; } = true;

        // Catalog.Staff önerilerinle uyumlu
        public int MaxConcurrentAppointments { get; set; } = 1;
        public int? BufferMinutes { get; set; }           // randevular arası boşluk
        public decimal RatingAvg { get; set; } = 0m;
        public int RatingCount { get; set; } = 0;
    }
}

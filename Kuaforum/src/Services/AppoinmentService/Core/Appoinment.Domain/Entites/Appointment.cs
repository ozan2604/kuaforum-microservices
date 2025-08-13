using Appoinment.Domain.Entites.Common;
using Appoinment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appoinment.Domain.Entites
{
    public class Appointment : BaseEntity
    {
        // Kimlikler (sadece GUID – cross-DB FK yok)
        public Guid CustomerId { get; set; }  // JWT’den
        public Guid VenueId { get; set; }     // Catalog.Venue
        public Guid StaffId { get; set; }     // Catalog.Staff
        public Guid ServiceId { get; set; }   // Catalog.Service

        // Zaman (UTC)
        public DateTime StartUtc { get; set; }
        public DateTime EndUtc { get; set; }

        // Durum
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;

        // Not/Süreç metaverisi
        public string? Notes { get; set; }
        public string? CorrelationId { get; set; }
        public byte[]? RowVersion { get; set; } // concurrency token

        // Snapshot (rezervasyon anında görüntülenecek bilgiler)
        public string VenueName { get; set; } = null!;
        public string StaffName { get; set; } = null!;
        public string ServiceName { get; set; } = null!;
        public int DurationMinutes { get; set; }          // efektif süre (override edilmiş olabilir)
        public decimal PriceAtBooking { get; set; }       // ödeme yok; bilgi amaçlı
        public string Currency { get; set; } = "TRY";
    }
}

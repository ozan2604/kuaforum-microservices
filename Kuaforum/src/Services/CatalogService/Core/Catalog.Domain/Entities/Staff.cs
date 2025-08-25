using Catalog.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Entities
{
    public class Staff : BaseEntity
    {
        public required Guid VenueId { get; set; }
        public Venue? Venue { get; set; }

        public required string Name { get; set; }
        public required string Surname { get; set; }
        public string PhoneNum { get; set; }
        public int? BufferMinutes { get; set; }          // randevu arası boşluk
        public int MaxConcurrentAppointments { get; set; } = 1;

        public string? Bio { get; set; } // kısa tanıtımı 
        public string? AvatarUrl { get; set; }

        public decimal RatingAvg { get; set; } = 0m;
        public int RatingCount { get; set; } = 0;

        public byte[]? RowVersion { get; set; }


        public ICollection<WorkSchedule> Schedules { get; set; } = new List<WorkSchedule>();
        public ICollection<Holiday> Holidays { get; set; } = new List<Holiday>();   // full-day
        public ICollection<StaffTimeOff> TimeOffs { get; set; } = new List<StaffTimeOff>(); // saatlik
        public ICollection<Service> services { get; set; } = new List<Service>();


    }
}

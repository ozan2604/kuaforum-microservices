using System;
using KuaforumContracts.Events.Common;

namespace KuaforumContracts.Events.Appointment
{
    public class AppointmentCreatedEvent : IEvent
    {
        public Guid AppointmentId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid VenueId { get; set; }
        public Guid StaffId { get; set; }
        public Guid ServiceId { get; set; }
        public DateTime StartUtc { get; set; }
        public DateTime EndUtc { get; set; }
        public string? Notes { get; set; }
    }
}

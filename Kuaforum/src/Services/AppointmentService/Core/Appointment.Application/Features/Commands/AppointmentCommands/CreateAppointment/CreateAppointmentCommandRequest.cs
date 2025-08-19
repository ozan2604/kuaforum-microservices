using Appointment.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.Features.Commands.AppointmentCommands.CreateAppointment
{
    public class CreateAppointmentCommandRequest : IRequest<CreateAppointmentCommandResponse>
    {
        public Guid VenueId { get; set; }
        public Guid StaffId { get; set; }
        public Guid ServiceId { get; set; }
        public DateTime StartUtc { get; set; }
        public DateTime EndUtc { get; set; }
        public string Notes { get; set; }
        public string CorrelationId { get; set; } // idempotency (opsiyonel)
    }
}

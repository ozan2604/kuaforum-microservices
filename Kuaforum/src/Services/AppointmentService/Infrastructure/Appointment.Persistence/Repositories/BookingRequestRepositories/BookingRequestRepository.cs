using Appointment.Application.Repositories.BookingRequestRepositories;
using Appointment.Domain.Entities;
using Appointment.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Persistence.Repositories.BookingRequestRepositories
{
    public class BookingRequestRepository : GenericRepository<BookingRequest> , IBookingRequestRepository
    {
        public BookingRequestRepository(AppointmentServiceDbContext context) : base(context)
        {
        }
    }
}

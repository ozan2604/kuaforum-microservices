using Appointment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Persistence.Contexts
{
    public class AppointmentServiceDbContext : DbContext
    {
        public AppointmentServiceDbContext(DbContextOptions<AppointmentServiceDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
         public DbSet<Appointment.Domain.Entities.Appointment> Appointments { get; set; }
         public DbSet<BookingRequest> BookingRequests { get; set; }
         public DbSet<AppointmentHistory> AppointmentHistories { get; set; }
    }
}

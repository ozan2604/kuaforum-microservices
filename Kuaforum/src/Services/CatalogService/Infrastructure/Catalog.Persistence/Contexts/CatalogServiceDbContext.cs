using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Persistence.Contexts
{
    public class CatalogServiceDbContext : DbContext
    {
        public CatalogServiceDbContext(DbContextOptions<CatalogServiceDbContext> options) : base(options)
        {
        }

        public DbSet<Venue> Venues { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<VenueTag> VenueTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<WorkSchedule> WorkSchedules { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<StaffTimeOff> StaffTimeOffs { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.Entity<Venue>(e =>
            {
                e.HasMany(x => x.Images)
                 .WithOne(x => x.Venue!)
                 .HasForeignKey(x => x.VenueId);

                e.HasMany(x => x.Staff)
                 .WithOne(x => x.Venue!)
                 .HasForeignKey(x => x.VenueId);

                e.HasMany(x => x.Services)
                 .WithOne(x => x.Venue!)
                 .HasForeignKey(x => x.VenueId);

                e.HasMany(x => x.Reviews)
                 .WithOne(x => x.Venue!)
                 .HasForeignKey(x => x.VenueId);

                e.HasMany(x => x.Likes)
                 .WithOne(x => x.Venue!)
                 .HasForeignKey(x => x.VenueId);

                e.HasMany(x => x.VenueTags)
                 .WithOne(x => x.Venue!)
                 .HasForeignKey(x => x.VenueId);
            });

            b.Entity<Image>(e =>
            {
                e.HasOne(x => x.Venue)
                 .WithMany(v => v.Images)
                 .HasForeignKey(x => x.VenueId);

                e.HasOne(x => x.Service)
                 .WithMany(s => s.Images)
                 .HasForeignKey(x => x.ServiceId);
            });

            b.Entity<Staff>(e =>
            {
                e.HasOne(x => x.Venue)
                 .WithMany(v => v.Staff)
                 .HasForeignKey(x => x.VenueId);

                e.HasMany(x => x.Schedules)
                 .WithOne(x => x.Staff!)
                 .HasForeignKey(x => x.StaffId);

                e.HasMany(x => x.Holidays)
                 .WithOne(x => x.Staff!)
                 .HasForeignKey(x => x.StaffId);

                e.HasMany(x => x.TimeOffs)
                 .WithOne(x => x.Staff!)
                 .HasForeignKey(x => x.StaffId);

                e.HasMany(x => x.services)
                 .WithMany(x => x.Staffs);
            });

            b.Entity<WorkSchedule>(e =>
            {
                e.HasOne(x => x.Staff)
                 .WithMany(x => x.Schedules)
                 .HasForeignKey(x => x.StaffId);
            });

            b.Entity<Holiday>(e =>
            {
                e.HasOne(x => x.Venue)
                 .WithMany()
                 .HasForeignKey(x => x.VenueId);

                e.HasOne(x => x.Staff)
                 .WithMany(x => x.Holidays)
                 .HasForeignKey(x => x.StaffId);
            });

            b.Entity<Service>(e =>
            {
                e.HasOne(x => x.Venue)
                 .WithMany(x => x.Services)
                 .HasForeignKey(x => x.VenueId);

                e.HasMany(x => x.Images)
                 .WithOne(x => x.Service!)
                 .HasForeignKey(x => x.ServiceId);

                e.HasMany(x => x.Staffs)
                 .WithMany(x => x.services);
            });

            b.Entity<Like>(e =>
            {
                e.HasOne(x => x.Venue)
                 .WithMany(x => x.Likes)
                 .HasForeignKey(x => x.VenueId);
            });

            b.Entity<Review>(e =>
            {
                e.HasOne(x => x.Venue)
                 .WithMany(x => x.Reviews)
                 .HasForeignKey(x => x.VenueId);
            });

            b.Entity<Tag>(e =>
            {
                e.HasMany(x => x.VenueTags)
                 .WithOne(x => x.Tag!)
                 .HasForeignKey(x => x.TagId);
            });

            b.Entity<VenueTag>(e =>
            {
                e.HasOne(x => x.Venue)
                 .WithMany(v => v.VenueTags)
                 .HasForeignKey(x => x.VenueId);

                e.HasOne(x => x.Tag)
                 .WithMany(t => t.VenueTags)
                 .HasForeignKey(x => x.TagId);
            });

            b.Entity<StaffTimeOff>(e =>
            {
                e.HasOne(x => x.Staff)
                 .WithMany(x => x.TimeOffs)
                 .HasForeignKey(x => x.StaffId);
            });
        }
    }
}


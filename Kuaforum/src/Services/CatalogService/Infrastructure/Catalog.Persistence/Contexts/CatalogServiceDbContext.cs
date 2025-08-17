using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Persistence.Contexts
{
    public class CatalogServiceDbContext : DbContext
    {
        public CatalogServiceDbContext(DbContextOptions<CatalogServiceDbContext> options) : base(options)
        {
        }

        public DbSet<Venue> Venues { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<VenuePhoto> VenuePhotos { get; set; }
        public DbSet<VenueTag> VenueTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ServicePhoto> ServicePhotos { get; set; }
        public DbSet<WorkSchedule> WorkSchedules { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<StaffService> StaffServices { get; set; }
        public DbSet<StaffSkill> StaffSkills { get; set; }
        public DbSet<StaffTimeOff> StaffTimeOffs { get; set; }

        protected override void OnModelCreating(ModelBuilder b)
        {
            
            b.Entity<Venue>(e =>
            {
                e.ToTable("venue");
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).IsRequired().HasMaxLength(200);
                e.Property(x => x.Type).HasConversion<int>();
                e.Property(x => x.Phone).IsRequired().HasMaxLength(32);
                e.Property(x => x.Email).HasMaxLength(256);
                e.Property(x => x.Website).HasMaxLength(256);

                e.Property(x => x.FullAddress).IsRequired().HasMaxLength(300);
                e.Property(x => x.City).IsRequired().HasMaxLength(120);
                e.Property(x => x.Country).IsRequired().HasMaxLength(2);
                e.Property(x => x.PostalCode).HasMaxLength(16);

                

                e.Property(x => x.AvgRating).HasColumnType("numeric(3,2)");
                e.Property(x => x.IsActive).HasDefaultValue(true);

                // Geometry (SRID 4326 = WGS84). İstersen "geography(Point,4326)" da kullanabilirsin.
                //e.Property(x => x.Location)
                 //.HasColumnType("geometry(Point,4326)");

                // ilişkiler
                e.HasMany(x => x.Photos).WithOne(x => x.Venue!).HasForeignKey(x => x.VenueId).OnDelete(DeleteBehavior.Cascade);
                e.HasMany(x => x.Staff).WithOne(x => x.Venue!).HasForeignKey(x => x.VenueId).OnDelete(DeleteBehavior.Cascade);
                e.HasMany(x => x.Services).WithOne(x => x.Venue!).HasForeignKey(x => x.VenueId).OnDelete(DeleteBehavior.Cascade);

                // indexler
                e.HasIndex(x => x.City);
                e.HasIndex(x => x.IsActive);
               // e.HasIndex(x => x.Location).HasMethod("gist"); // geospatial
            });

            // VenuePhoto
            b.Entity<VenuePhoto>(e =>
            {
                e.ToTable("venue_photo");
                e.HasKey(x => x.Id);
                e.Property(x => x.Url).IsRequired().HasMaxLength(512);
                e.Property(x => x.IsCover).HasDefaultValue(false);
            });

            // Staff
            b.Entity<Staff>(e =>
            {
                e.ToTable("staff");
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).IsRequired().HasMaxLength(120);
                e.Property(x => x.Surname).IsRequired().HasMaxLength(120);
                e.Property(x => x.Skills).HasColumnType("jsonb");
                e.Property(x => x.IsActive).HasDefaultValue(true);
                e.HasIndex(x => new { x.VenueId, x.IsActive });
            });

            // WorkSchedule
            b.Entity<WorkSchedule>(e =>
            {
                e.ToTable("work_schedule");
                e.HasKey(x => x.Id);
                e.Property(x => x.DayOfWeek).HasConversion<int>();
                e.Property(x => x.StartTime).HasConversion(
                    v => v.ToTimeSpan(), v => TimeOnly.FromTimeSpan(v));
                e.Property(x => x.EndTime).HasConversion(
                    v => v.ToTimeSpan(), v => TimeOnly.FromTimeSpan(v));
                e.Property(x => x.BreakStart).HasConversion(
                    v => v.HasValue ? v.Value.ToTimeSpan() : (TimeSpan?)null,
                    v => v.HasValue ? TimeOnly.FromTimeSpan(v.Value) : (TimeOnly?)null);
                e.Property(x => x.BreakEnd).HasConversion(
                    v => v.HasValue ? v.Value.ToTimeSpan() : (TimeSpan?)null,
                    v => v.HasValue ? TimeOnly.FromTimeSpan(v.Value) : (TimeOnly?)null);

                e.HasIndex(x => new { x.StaffId, x.DayOfWeek });
            });

            
            b.Entity<Holiday>(e =>
            {
                e.ToTable("holiday");
                e.HasKey(x => x.Id);
                e.Property(x => x.Date).HasConversion(
                    v => v.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc),
                    v => DateOnly.FromDateTime(DateTime.SpecifyKind(v, DateTimeKind.Utc)));
                e.HasIndex(x => new { x.VenueId, x.Date });
                e.HasIndex(x => new { x.StaffId, x.Date });
            });

            // Service
            b.Entity<Service>(e =>
            {
                e.ToTable("service");
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).IsRequired().HasMaxLength(160);
                e.Property(x => x.Category).HasMaxLength(80);
                e.Property(x => x.DurationMinutes).IsRequired();
                e.Property(x => x.Price).HasColumnType("numeric(10,2)");
                e.Property(x => x.Currency).IsRequired().HasMaxLength(3);
                e.Property(x => x.Gender).HasMaxLength(16);
                e.Property(x => x.IsActive).HasDefaultValue(true);

                e.HasIndex(x => new { x.VenueId, x.IsActive });
                e.HasIndex(x => new { x.VenueId, x.Name }).IsUnique(); // aynı mekanda aynı isimde tek hizmet
            });

            // ServicePhoto
            b.Entity<ServicePhoto>(e =>
            {
                e.ToTable("service_photo");
                e.HasKey(x => x.Id);
                e.Property(x => x.Url).IsRequired().HasMaxLength(512);
            });

            // Like
            b.Entity<Like>(e =>
            {
                e.ToTable("like");
                e.HasKey(x => x.Id);
                e.HasIndex(x => new { x.VenueId, x.UserId }).IsUnique(); // kullanıcı başına tek beğeni
            });

            // Review
            b.Entity<Review>(e =>
            {
                e.ToTable("review");
                e.HasKey(x => x.Id);
                e.Property(x => x.Rating).IsRequired();
                e.Property(x => x.Comment).HasMaxLength(2000);
                e.Property(x => x.Photos).HasColumnType("jsonb");
                e.Property(x => x.IsVerifiedReservation).HasDefaultValue(false);

                e.HasIndex(x => new { x.VenueId, x.CreateAt });
            });

            // Tag
            b.Entity<Tag>(e =>
            {
                e.ToTable("tag");
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).IsRequired().HasMaxLength(64);
                e.Property(x => x.Type).HasMaxLength(32);
                e.Property(x => x.IsActive).HasDefaultValue(true);
                e.HasIndex(x => x.Name).IsUnique();
            });

            // VenueTag (join)
            b.Entity<VenueTag>(e =>
            {
                e.ToTable("venue_tag");
                e.HasKey(x => new { x.VenueId, x.TagId });
                e.HasOne(x => x.Venue).WithMany(v => v.VenueTags).HasForeignKey(x => x.VenueId).OnDelete(DeleteBehavior.Cascade);
                e.HasOne(x => x.Tag).WithMany(t => t.VenueTags).HasForeignKey(x => x.TagId).OnDelete(DeleteBehavior.Cascade);
            });
        }


    }
}

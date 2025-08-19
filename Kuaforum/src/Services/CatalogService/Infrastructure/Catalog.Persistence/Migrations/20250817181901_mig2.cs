using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_review_VenueId_CreateAt",
                table: "review");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "work_schedule");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "venue_photo");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "venue");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "tag");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "StaffTimeOffs");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "StaffSkills");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "StaffServices");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "staff");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "service_photo");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "service");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "review");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "like");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "holiday");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "work_schedule",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "work_schedule",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "venue_photo",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "venue_photo",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "venue",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "venue",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "tag",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "tag",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "StaffTimeOffs",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "StaffTimeOffs",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "StaffSkills",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "StaffSkills",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "StaffServices",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "StaffServices",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "staff",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "staff",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "service_photo",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "service_photo",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "service",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "service",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "review",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "review",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "like",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "like",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "holiday",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "holiday",
                newName: "DeletedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "work_schedule",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "venue_photo",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "venue",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "tag",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "StaffTimeOffs",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "StaffSkills",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "StaffServices",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "staff",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "service_photo",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "service",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "review",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "like",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "holiday",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_review_VenueId_CreatedAt",
                table: "review",
                columns: new[] { "VenueId", "CreatedAt" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_review_VenueId_CreatedAt",
                table: "review");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "work_schedule");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "venue_photo");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "venue");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "tag");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "StaffTimeOffs");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "StaffSkills");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "StaffServices");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "staff");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "service_photo");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "service");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "review");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "like");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "holiday");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "work_schedule",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "work_schedule",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "venue_photo",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "venue_photo",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "venue",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "venue",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "tag",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "tag",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "StaffTimeOffs",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "StaffTimeOffs",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "StaffSkills",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "StaffSkills",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "StaffServices",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "StaffServices",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "staff",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "staff",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "service_photo",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "service_photo",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "service",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "service",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "review",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "review",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "like",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "like",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "holiday",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "holiday",
                newName: "DeleteAt");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateAt",
                table: "work_schedule",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateAt",
                table: "venue_photo",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateAt",
                table: "venue",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateAt",
                table: "tag",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateAt",
                table: "StaffTimeOffs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateAt",
                table: "StaffSkills",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateAt",
                table: "StaffServices",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateAt",
                table: "staff",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateAt",
                table: "service_photo",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateAt",
                table: "service",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateAt",
                table: "review",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateAt",
                table: "like",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateAt",
                table: "holiday",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_review_VenueId_CreateAt",
                table: "review",
                columns: new[] { "VenueId", "CreateAt" });
        }
    }
}

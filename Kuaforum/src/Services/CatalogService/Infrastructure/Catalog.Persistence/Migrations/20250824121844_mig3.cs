using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_holiday_staff_StaffId",
                table: "holiday");

            migrationBuilder.DropForeignKey(
                name: "FK_holiday_venue_VenueId",
                table: "holiday");

            migrationBuilder.DropForeignKey(
                name: "FK_like_venue_VenueId",
                table: "like");

            migrationBuilder.DropForeignKey(
                name: "FK_review_venue_VenueId",
                table: "review");

            migrationBuilder.DropForeignKey(
                name: "FK_service_venue_VenueId",
                table: "service");

            migrationBuilder.DropForeignKey(
                name: "FK_service_photo_service_ServiceId",
                table: "service_photo");

            migrationBuilder.DropForeignKey(
                name: "FK_staff_venue_VenueId",
                table: "staff");

            migrationBuilder.DropForeignKey(
                name: "FK_venue_photo_venue_VenueId",
                table: "venue_photo");

            migrationBuilder.DropForeignKey(
                name: "FK_venue_tag_tag_TagId",
                table: "venue_tag");

            migrationBuilder.DropForeignKey(
                name: "FK_venue_tag_venue_VenueId",
                table: "venue_tag");

            migrationBuilder.DropForeignKey(
                name: "FK_work_schedule_staff_StaffId",
                table: "work_schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_work_schedule",
                table: "work_schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_venue_tag",
                table: "venue_tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_venue_photo",
                table: "venue_photo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_venue",
                table: "venue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tag",
                table: "tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_service_photo",
                table: "service_photo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_service",
                table: "service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_review",
                table: "review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_like",
                table: "like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_holiday",
                table: "holiday");

            migrationBuilder.RenameTable(
                name: "work_schedule",
                newName: "WorkSchedules");

            migrationBuilder.RenameTable(
                name: "venue_tag",
                newName: "VenueTags");

            migrationBuilder.RenameTable(
                name: "venue_photo",
                newName: "VenuePhotos");

            migrationBuilder.RenameTable(
                name: "venue",
                newName: "venues");

            migrationBuilder.RenameTable(
                name: "tag",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "service_photo",
                newName: "ServicePhotos");

            migrationBuilder.RenameTable(
                name: "service",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "review",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "like",
                newName: "Likes");

            migrationBuilder.RenameTable(
                name: "holiday",
                newName: "Holidays");

            migrationBuilder.RenameIndex(
                name: "IX_work_schedule_StaffId_DayOfWeek",
                table: "WorkSchedules",
                newName: "IX_WorkSchedules_StaffId_DayOfWeek");

            migrationBuilder.RenameIndex(
                name: "IX_venue_tag_TagId",
                table: "VenueTags",
                newName: "IX_VenueTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_venue_photo_VenueId",
                table: "VenuePhotos",
                newName: "IX_VenuePhotos_VenueId");

            migrationBuilder.RenameIndex(
                name: "IX_venue_IsActive",
                table: "venues",
                newName: "IX_venues_IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_venue_City",
                table: "venues",
                newName: "IX_venues_City");

            migrationBuilder.RenameIndex(
                name: "IX_tag_Name",
                table: "Tags",
                newName: "IX_Tags_Name");

            migrationBuilder.RenameIndex(
                name: "IX_service_photo_ServiceId",
                table: "ServicePhotos",
                newName: "IX_ServicePhotos_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_service_VenueId_Name",
                table: "Services",
                newName: "IX_Services_VenueId_Name");

            migrationBuilder.RenameIndex(
                name: "IX_service_VenueId_IsActive",
                table: "Services",
                newName: "IX_Services_VenueId_IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_review_VenueId_CreatedAt",
                table: "Reviews",
                newName: "IX_Reviews_VenueId_CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_like_VenueId_UserId",
                table: "Likes",
                newName: "IX_Likes_VenueId_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_holiday_VenueId_Date",
                table: "Holidays",
                newName: "IX_Holidays_VenueId_Date");

            migrationBuilder.RenameIndex(
                name: "IX_holiday_StaffId_Date",
                table: "Holidays",
                newName: "IX_Holidays_StaffId_Date");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "venues",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(2)",
                oldMaxLength: 2);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkSchedules",
                table: "WorkSchedules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VenueTags",
                table: "VenueTags",
                columns: new[] { "VenueId", "TagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_VenuePhotos",
                table: "VenuePhotos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_venues",
                table: "venues",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServicePhotos",
                table: "ServicePhotos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Holidays",
                table: "Holidays",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Holidays_staff_StaffId",
                table: "Holidays",
                column: "StaffId",
                principalTable: "staff",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Holidays_venues_VenueId",
                table: "Holidays",
                column: "VenueId",
                principalTable: "venues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_venues_VenueId",
                table: "Likes",
                column: "VenueId",
                principalTable: "venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_venues_VenueId",
                table: "Reviews",
                column: "VenueId",
                principalTable: "venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePhotos_Services_ServiceId",
                table: "ServicePhotos",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_venues_VenueId",
                table: "Services",
                column: "VenueId",
                principalTable: "venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_staff_venues_VenueId",
                table: "staff",
                column: "VenueId",
                principalTable: "venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VenuePhotos_venues_VenueId",
                table: "VenuePhotos",
                column: "VenueId",
                principalTable: "venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VenueTags_Tags_TagId",
                table: "VenueTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VenueTags_venues_VenueId",
                table: "VenueTags",
                column: "VenueId",
                principalTable: "venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSchedules_staff_StaffId",
                table: "WorkSchedules",
                column: "StaffId",
                principalTable: "staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holidays_staff_StaffId",
                table: "Holidays");

            migrationBuilder.DropForeignKey(
                name: "FK_Holidays_venues_VenueId",
                table: "Holidays");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_venues_VenueId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_venues_VenueId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicePhotos_Services_ServiceId",
                table: "ServicePhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_venues_VenueId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_staff_venues_VenueId",
                table: "staff");

            migrationBuilder.DropForeignKey(
                name: "FK_VenuePhotos_venues_VenueId",
                table: "VenuePhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_VenueTags_Tags_TagId",
                table: "VenueTags");

            migrationBuilder.DropForeignKey(
                name: "FK_VenueTags_venues_VenueId",
                table: "VenueTags");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkSchedules_staff_StaffId",
                table: "WorkSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkSchedules",
                table: "WorkSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VenueTags",
                table: "VenueTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_venues",
                table: "venues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VenuePhotos",
                table: "VenuePhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServicePhotos",
                table: "ServicePhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Holidays",
                table: "Holidays");

            migrationBuilder.RenameTable(
                name: "WorkSchedules",
                newName: "work_schedule");

            migrationBuilder.RenameTable(
                name: "VenueTags",
                newName: "venue_tag");

            migrationBuilder.RenameTable(
                name: "venues",
                newName: "venue");

            migrationBuilder.RenameTable(
                name: "VenuePhotos",
                newName: "venue_photo");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "tag");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "service");

            migrationBuilder.RenameTable(
                name: "ServicePhotos",
                newName: "service_photo");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "review");

            migrationBuilder.RenameTable(
                name: "Likes",
                newName: "like");

            migrationBuilder.RenameTable(
                name: "Holidays",
                newName: "holiday");

            migrationBuilder.RenameIndex(
                name: "IX_WorkSchedules_StaffId_DayOfWeek",
                table: "work_schedule",
                newName: "IX_work_schedule_StaffId_DayOfWeek");

            migrationBuilder.RenameIndex(
                name: "IX_VenueTags_TagId",
                table: "venue_tag",
                newName: "IX_venue_tag_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_venues_IsActive",
                table: "venue",
                newName: "IX_venue_IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_venues_City",
                table: "venue",
                newName: "IX_venue_City");

            migrationBuilder.RenameIndex(
                name: "IX_VenuePhotos_VenueId",
                table: "venue_photo",
                newName: "IX_venue_photo_VenueId");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_Name",
                table: "tag",
                newName: "IX_tag_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Services_VenueId_Name",
                table: "service",
                newName: "IX_service_VenueId_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Services_VenueId_IsActive",
                table: "service",
                newName: "IX_service_VenueId_IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_ServicePhotos_ServiceId",
                table: "service_photo",
                newName: "IX_service_photo_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_VenueId_CreatedAt",
                table: "review",
                newName: "IX_review_VenueId_CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_VenueId_UserId",
                table: "like",
                newName: "IX_like_VenueId_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Holidays_VenueId_Date",
                table: "holiday",
                newName: "IX_holiday_VenueId_Date");

            migrationBuilder.RenameIndex(
                name: "IX_Holidays_StaffId_Date",
                table: "holiday",
                newName: "IX_holiday_StaffId_Date");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "venue",
                type: "character varying(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_work_schedule",
                table: "work_schedule",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_venue_tag",
                table: "venue_tag",
                columns: new[] { "VenueId", "TagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_venue",
                table: "venue",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_venue_photo",
                table: "venue_photo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tag",
                table: "tag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_service",
                table: "service",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_service_photo",
                table: "service_photo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_review",
                table: "review",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_like",
                table: "like",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_holiday",
                table: "holiday",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_holiday_staff_StaffId",
                table: "holiday",
                column: "StaffId",
                principalTable: "staff",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_holiday_venue_VenueId",
                table: "holiday",
                column: "VenueId",
                principalTable: "venue",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_like_venue_VenueId",
                table: "like",
                column: "VenueId",
                principalTable: "venue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_review_venue_VenueId",
                table: "review",
                column: "VenueId",
                principalTable: "venue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_service_venue_VenueId",
                table: "service",
                column: "VenueId",
                principalTable: "venue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_service_photo_service_ServiceId",
                table: "service_photo",
                column: "ServiceId",
                principalTable: "service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_staff_venue_VenueId",
                table: "staff",
                column: "VenueId",
                principalTable: "venue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_venue_photo_venue_VenueId",
                table: "venue_photo",
                column: "VenueId",
                principalTable: "venue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_venue_tag_tag_TagId",
                table: "venue_tag",
                column: "TagId",
                principalTable: "tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_venue_tag_venue_VenueId",
                table: "venue_tag",
                column: "VenueId",
                principalTable: "venue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_work_schedule_staff_StaffId",
                table: "work_schedule",
                column: "StaffId",
                principalTable: "staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

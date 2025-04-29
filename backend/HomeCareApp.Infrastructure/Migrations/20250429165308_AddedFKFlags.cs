using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeCareApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedFKFlags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_CareRequests_MCareRequestId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_MCareRequestId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "MCareRequestId",
                table: "Bookings");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RequestId",
                table: "Bookings",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_CareRequests_RequestId",
                table: "Bookings",
                column: "RequestId",
                principalTable: "CareRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_CareRequests_RequestId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_RequestId",
                table: "Bookings");

            migrationBuilder.AddColumn<Guid>(
                name: "MCareRequestId",
                table: "Bookings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_MCareRequestId",
                table: "Bookings",
                column: "MCareRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_CareRequests_MCareRequestId",
                table: "Bookings",
                column: "MCareRequestId",
                principalTable: "CareRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeviceTracker.Web.Data.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class UptimeMetricColUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uptime",
                table: "UptimeData");

            migrationBuilder.AddColumn<bool>(
                name: "IsGeneratorRunning",
                table: "UptimeData",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsGeneratorRunning",
                table: "UptimeData");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "Uptime",
                table: "UptimeData",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }
    }
}

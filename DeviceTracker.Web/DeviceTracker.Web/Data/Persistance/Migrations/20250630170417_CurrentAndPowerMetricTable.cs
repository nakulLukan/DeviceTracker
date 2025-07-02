using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DeviceTracker.Web.Data.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class CurrentAndPowerMetricTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BatteryMetrics",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MainBattery = table.Column<float>(type: "real", nullable: false),
                    BackupBattery = table.Column<float>(type: "real", nullable: false),
                    DeviceId = table.Column<int>(type: "integer", nullable: false),
                    Instant = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatteryMetrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatteryMetrics_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BatteryMetrics_DeviceId",
                table: "BatteryMetrics",
                column: "DeviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatteryMetrics");
        }
    }
}

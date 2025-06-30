using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DeviceTracker.Web.Data.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AllMetricTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "V2",
                table: "VoltageMetrics",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "V3",
                table: "VoltageMetrics",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "CurrentMetrics",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    I1 = table.Column<float>(type: "real", nullable: false),
                    I2 = table.Column<float>(type: "real", nullable: false),
                    I3 = table.Column<float>(type: "real", nullable: false),
                    DeviceId = table.Column<int>(type: "integer", nullable: false),
                    Instant = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentMetrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentMetrics_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Lat = table.Column<double>(type: "double precision", nullable: false),
                    Lng = table.Column<double>(type: "double precision", nullable: false),
                    DeviceId = table.Column<int>(type: "integer", nullable: false),
                    Instant = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationData_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PowerMetrics",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    P1 = table.Column<float>(type: "real", nullable: false),
                    P2 = table.Column<float>(type: "real", nullable: false),
                    P3 = table.Column<float>(type: "real", nullable: false),
                    DeviceId = table.Column<int>(type: "integer", nullable: false),
                    Instant = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerMetrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PowerMetrics_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelayMetrics",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartStopRelay = table.Column<bool>(type: "boolean", nullable: false),
                    FuelCutRelay = table.Column<bool>(type: "boolean", nullable: false),
                    DeviceId = table.Column<int>(type: "integer", nullable: false),
                    Instant = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelayMetrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelayMetrics_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UptimeData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uptime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    DeviceId = table.Column<int>(type: "integer", nullable: false),
                    Instant = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UptimeData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UptimeData_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrentMetrics_DeviceId",
                table: "CurrentMetrics",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationData_DeviceId",
                table: "LocationData",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerMetrics_DeviceId",
                table: "PowerMetrics",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_RelayMetrics_DeviceId",
                table: "RelayMetrics",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_UptimeData_DeviceId",
                table: "UptimeData",
                column: "DeviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentMetrics");

            migrationBuilder.DropTable(
                name: "LocationData");

            migrationBuilder.DropTable(
                name: "PowerMetrics");

            migrationBuilder.DropTable(
                name: "RelayMetrics");

            migrationBuilder.DropTable(
                name: "UptimeData");

            migrationBuilder.DropColumn(
                name: "V2",
                table: "VoltageMetrics");

            migrationBuilder.DropColumn(
                name: "V3",
                table: "VoltageMetrics");
        }
    }
}

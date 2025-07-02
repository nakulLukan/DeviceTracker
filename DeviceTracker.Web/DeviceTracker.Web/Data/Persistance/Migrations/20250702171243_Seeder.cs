using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeviceTracker.Web.Data.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Seeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Devices_DeviceName",
                table: "Devices",
                column: "DeviceName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Devices_DeviceName",
                table: "Devices");
        }
    }
}

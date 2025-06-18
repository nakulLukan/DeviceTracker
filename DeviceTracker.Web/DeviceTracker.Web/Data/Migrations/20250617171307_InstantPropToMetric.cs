﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeviceTracker.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class InstantPropToMetric : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Instant",
                table: "VoltageMetrics",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Instant",
                table: "VoltageMetrics");
        }
    }
}

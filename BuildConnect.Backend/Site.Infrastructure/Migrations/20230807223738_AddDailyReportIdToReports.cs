using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Site.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDailyReportIdToReports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DailyReportId",
                table: "MaterialReports",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DailyReportId",
                table: "LabourForces",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DailyReportId",
                table: "MaterialReports");

            migrationBuilder.DropColumn(
                name: "DailyReportId",
                table: "LabourForces");
        }
    }
}

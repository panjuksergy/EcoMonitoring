using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoMonitoringService.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AmmoniaFormaldehyde",
                table: "EcoRecords",
                newName: "Formaldehyde");

            migrationBuilder.AddColumn<double>(
                name: "Ammonia",
                table: "EcoRecords",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ammonia",
                table: "EcoRecords");

            migrationBuilder.RenameColumn(
                name: "Formaldehyde",
                table: "EcoRecords",
                newName: "AmmoniaFormaldehyde");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoMonitoringService.Migrations
{
    /// <inheritdoc />
    public partial class cancerriskinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AmmoniaCancerStat",
                table: "MonitoringSingleStats",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CarbonDioxideCancerStat",
                table: "MonitoringSingleStats",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FormaldehydeCancerStat",
                table: "MonitoringSingleStats",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HydrogenFluorideCancerStat",
                table: "MonitoringSingleStats",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NitrogenDioxideCancerStat",
                table: "MonitoringSingleStats",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SulfurDioxideCancerStat",
                table: "MonitoringSingleStats",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SuspendedSolidsCancerStat",
                table: "MonitoringSingleStats",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalCancerRisk",
                table: "MonitoringSingleStats",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmmoniaCancerStat",
                table: "MonitoringSingleStats");

            migrationBuilder.DropColumn(
                name: "CarbonDioxideCancerStat",
                table: "MonitoringSingleStats");

            migrationBuilder.DropColumn(
                name: "FormaldehydeCancerStat",
                table: "MonitoringSingleStats");

            migrationBuilder.DropColumn(
                name: "HydrogenFluorideCancerStat",
                table: "MonitoringSingleStats");

            migrationBuilder.DropColumn(
                name: "NitrogenDioxideCancerStat",
                table: "MonitoringSingleStats");

            migrationBuilder.DropColumn(
                name: "SulfurDioxideCancerStat",
                table: "MonitoringSingleStats");

            migrationBuilder.DropColumn(
                name: "SuspendedSolidsCancerStat",
                table: "MonitoringSingleStats");

            migrationBuilder.DropColumn(
                name: "TotalCancerRisk",
                table: "MonitoringSingleStats");
        }
    }
}

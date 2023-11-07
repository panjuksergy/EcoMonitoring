using System;
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
            migrationBuilder.CreateTable(
                name: "EcoRecords",
                columns: table => new
                {
                    RecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SuspendedSolids = table.Column<double>(type: "float", nullable: false),
                    SulfurDioxide = table.Column<double>(type: "float", nullable: false),
                    CarbonDioxide = table.Column<double>(type: "float", nullable: false),
                    NitrogenDioxide = table.Column<double>(type: "float", nullable: false),
                    HydrogenFluoride = table.Column<double>(type: "float", nullable: false),
                    Ammonia = table.Column<double>(type: "float", nullable: false),
                    Formaldehyde = table.Column<double>(type: "float", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MonitoringSingleStatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcoRecords", x => x.RecordId);
                });

            migrationBuilder.CreateTable(
                name: "MonitoringSingleStats",
                columns: table => new
                {
                    MonitoringSingleStatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EcoRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SuspendedSolidsStat = table.Column<double>(type: "float", nullable: false),
                    SulfurDioxideStat = table.Column<double>(type: "float", nullable: false),
                    CarbonDioxideStat = table.Column<double>(type: "float", nullable: false),
                    NitrogenDioxideStat = table.Column<double>(type: "float", nullable: false),
                    HydrogenFluorideStat = table.Column<double>(type: "float", nullable: false),
                    AmmoniaStat = table.Column<double>(type: "float", nullable: false),
                    FormaldehydeStat = table.Column<double>(type: "float", nullable: false),
                    TotalNonCancerRisk = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitoringSingleStats", x => x.MonitoringSingleStatId);
                    table.ForeignKey(
                        name: "FK_MonitoringSingleStats_EcoRecords_EcoRecordId",
                        column: x => x.EcoRecordId,
                        principalTable: "EcoRecords",
                        principalColumn: "RecordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonitoringSingleStats_EcoRecordId",
                table: "MonitoringSingleStats",
                column: "EcoRecordId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonitoringSingleStats");

            migrationBuilder.DropTable(
                name: "EcoRecords");
        }
    }
}

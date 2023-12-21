using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoMonitoringService.Migrations
{
    /// <inheritdoc />
    public partial class MinorFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonitoringSingleStats_EcoRecords_EcoRecordId",
                table: "MonitoringSingleStats");

            migrationBuilder.RenameColumn(
                name: "EcoRecordId",
                table: "MonitoringSingleStats",
                newName: "RecordId");

            migrationBuilder.RenameIndex(
                name: "IX_MonitoringSingleStats_EcoRecordId",
                table: "MonitoringSingleStats",
                newName: "IX_MonitoringSingleStats_RecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonitoringSingleStats_EcoRecords_RecordId",
                table: "MonitoringSingleStats",
                column: "RecordId",
                principalTable: "EcoRecords",
                principalColumn: "RecordId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonitoringSingleStats_EcoRecords_RecordId",
                table: "MonitoringSingleStats");

            migrationBuilder.RenameColumn(
                name: "RecordId",
                table: "MonitoringSingleStats",
                newName: "EcoRecordId");

            migrationBuilder.RenameIndex(
                name: "IX_MonitoringSingleStats_RecordId",
                table: "MonitoringSingleStats",
                newName: "IX_MonitoringSingleStats_EcoRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonitoringSingleStats_EcoRecords_EcoRecordId",
                table: "MonitoringSingleStats",
                column: "EcoRecordId",
                principalTable: "EcoRecords",
                principalColumn: "RecordId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

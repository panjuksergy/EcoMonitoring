using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoMonitoringService.Migrations
{
    /// <inheritdoc />
    public partial class refundInvoiceTableCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RefundInvoiceRefundId",
                table: "EcoRecords",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RefundInvoices",
                columns: table => new
                {
                    RefundId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Money = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefundInvoices", x => x.RefundId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EcoRecords_RefundInvoiceRefundId",
                table: "EcoRecords",
                column: "RefundInvoiceRefundId");

            migrationBuilder.AddForeignKey(
                name: "FK_EcoRecords_RefundInvoices_RefundInvoiceRefundId",
                table: "EcoRecords",
                column: "RefundInvoiceRefundId",
                principalTable: "RefundInvoices",
                principalColumn: "RefundId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcoRecords_RefundInvoices_RefundInvoiceRefundId",
                table: "EcoRecords");

            migrationBuilder.DropTable(
                name: "RefundInvoices");

            migrationBuilder.DropIndex(
                name: "IX_EcoRecords_RefundInvoiceRefundId",
                table: "EcoRecords");

            migrationBuilder.DropColumn(
                name: "RefundInvoiceRefundId",
                table: "EcoRecords");
        }
    }
}

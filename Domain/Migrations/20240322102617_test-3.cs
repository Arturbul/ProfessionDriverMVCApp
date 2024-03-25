using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverWorkLogs_DriverWorkLogDetails_DriverWorkLogId",
                table: "DriverWorkLogs");

            migrationBuilder.CreateIndex(
                name: "IX_DriverWorkLogDetails_DriverWorkLogId",
                table: "DriverWorkLogDetails",
                column: "DriverWorkLogId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverWorkLogDetails_DriverWorkLogs_DriverWorkLogId",
                table: "DriverWorkLogDetails",
                column: "DriverWorkLogId",
                principalTable: "DriverWorkLogs",
                principalColumn: "DriverWorkLogId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverWorkLogDetails_DriverWorkLogs_DriverWorkLogId",
                table: "DriverWorkLogDetails");

            migrationBuilder.DropIndex(
                name: "IX_DriverWorkLogDetails_DriverWorkLogId",
                table: "DriverWorkLogDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverWorkLogs_DriverWorkLogDetails_DriverWorkLogId",
                table: "DriverWorkLogs",
                column: "DriverWorkLogId",
                principalTable: "DriverWorkLogDetails",
                principalColumn: "DriverWorkLogDetailId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

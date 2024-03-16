using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class testContextChanges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverWorkLogEntries_DriverWorkLogs_DriverWorkLogId",
                table: "DriverWorkLogEntries");

            migrationBuilder.DropIndex(
                name: "IX_DriverWorkLogEntries_DriverWorkLogId",
                table: "DriverWorkLogEntries");

            migrationBuilder.AlterColumn<Guid>(
                name: "DriverWorkLogId",
                table: "DriverWorkLogEntries",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_DriverWorkLogEntries_DriverWorkLogId",
                table: "DriverWorkLogEntries",
                column: "DriverWorkLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverWorkLogEntries_DriverWorkLogs_DriverWorkLogId",
                table: "DriverWorkLogEntries",
                column: "DriverWorkLogId",
                principalTable: "DriverWorkLogs",
                principalColumn: "DriverWorkLogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverWorkLogEntries_DriverWorkLogs_DriverWorkLogId",
                table: "DriverWorkLogEntries");

            migrationBuilder.DropIndex(
                name: "IX_DriverWorkLogEntries_DriverWorkLogId",
                table: "DriverWorkLogEntries");

            migrationBuilder.AlterColumn<Guid>(
                name: "DriverWorkLogId",
                table: "DriverWorkLogEntries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DriverWorkLogEntries_DriverWorkLogId",
                table: "DriverWorkLogEntries",
                column: "DriverWorkLogId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverWorkLogEntries_DriverWorkLogs_DriverWorkLogId",
                table: "DriverWorkLogEntries",
                column: "DriverWorkLogId",
                principalTable: "DriverWorkLogs",
                principalColumn: "DriverWorkLogId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class testContextChanges1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverWorkLogEntrys_Drivers_DriverId",
                table: "DriverWorkLogEntrys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverWorkLogEntrys",
                table: "DriverWorkLogEntrys");

            migrationBuilder.RenameTable(
                name: "DriverWorkLogEntrys",
                newName: "DriverWorkLogEntries");

            migrationBuilder.RenameIndex(
                name: "IX_DriverWorkLogEntrys_DriverId",
                table: "DriverWorkLogEntries",
                newName: "IX_DriverWorkLogEntries_DriverId");

            migrationBuilder.AddColumn<Guid>(
                name: "DriverWorkLogId",
                table: "DriverWorkLogEntries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverWorkLogEntries",
                table: "DriverWorkLogEntries",
                column: "DriverWorkLogEntryId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_DriverWorkLogEntries_Drivers_DriverId",
                table: "DriverWorkLogEntries",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverWorkLogEntries_DriverWorkLogs_DriverWorkLogId",
                table: "DriverWorkLogEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverWorkLogEntries_Drivers_DriverId",
                table: "DriverWorkLogEntries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverWorkLogEntries",
                table: "DriverWorkLogEntries");

            migrationBuilder.DropIndex(
                name: "IX_DriverWorkLogEntries_DriverWorkLogId",
                table: "DriverWorkLogEntries");

            migrationBuilder.DropColumn(
                name: "DriverWorkLogId",
                table: "DriverWorkLogEntries");

            migrationBuilder.RenameTable(
                name: "DriverWorkLogEntries",
                newName: "DriverWorkLogEntrys");

            migrationBuilder.RenameIndex(
                name: "IX_DriverWorkLogEntries_DriverId",
                table: "DriverWorkLogEntrys",
                newName: "IX_DriverWorkLogEntrys_DriverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverWorkLogEntrys",
                table: "DriverWorkLogEntrys",
                column: "DriverWorkLogEntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverWorkLogEntrys_Drivers_DriverId",
                table: "DriverWorkLogEntrys",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfessionDriverApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModelUpdate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverWorkLogs_TransportUnit_TransportUnitId",
                table: "DriverWorkLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransportUnit",
                table: "TransportUnit");

            migrationBuilder.RenameTable(
                name: "TransportUnit",
                newName: "TransportUnits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransportUnits",
                table: "TransportUnits",
                column: "TransportUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverWorkLogs_TransportUnits_TransportUnitId",
                table: "DriverWorkLogs",
                column: "TransportUnitId",
                principalTable: "TransportUnits",
                principalColumn: "TransportUnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverWorkLogs_TransportUnits_TransportUnitId",
                table: "DriverWorkLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransportUnits",
                table: "TransportUnits");

            migrationBuilder.RenameTable(
                name: "TransportUnits",
                newName: "TransportUnit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransportUnit",
                table: "TransportUnit",
                column: "TransportUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverWorkLogs_TransportUnit_TransportUnitId",
                table: "DriverWorkLogs",
                column: "TransportUnitId",
                principalTable: "TransportUnit",
                principalColumn: "TransportUnitId");
        }
    }
}

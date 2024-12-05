using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfessionDriverApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModelUpdate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverWorkLogs_LargeGoodsVehicles_LargeGoodsVehicleId",
                table: "DriverWorkLogs");

            migrationBuilder.DropTable(
                name: "LargeGoodsVehicles");

            migrationBuilder.RenameColumn(
                name: "LargeGoodsVehicleId",
                table: "DriverWorkLogs",
                newName: "TransportUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_DriverWorkLogs_LargeGoodsVehicleId",
                table: "DriverWorkLogs",
                newName: "IX_DriverWorkLogs_TransportUnitId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Vehicles",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LargeGoodsVehicleId",
                table: "Vehicles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "TachoExpiryDate",
                table: "Vehicles",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LargeGoodsVehicleVehicleId",
                table: "DriverWorkLogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TransportUnit",
                columns: table => new
                {
                    TransportUnitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationNumberTrailer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportUnit", x => x.TransportUnitId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DriverWorkLogs_LargeGoodsVehicleVehicleId",
                table: "DriverWorkLogs",
                column: "LargeGoodsVehicleVehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverWorkLogs_TransportUnit_TransportUnitId",
                table: "DriverWorkLogs",
                column: "TransportUnitId",
                principalTable: "TransportUnit",
                principalColumn: "TransportUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverWorkLogs_Vehicles_LargeGoodsVehicleVehicleId",
                table: "DriverWorkLogs",
                column: "LargeGoodsVehicleVehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverWorkLogs_TransportUnit_TransportUnitId",
                table: "DriverWorkLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverWorkLogs_Vehicles_LargeGoodsVehicleVehicleId",
                table: "DriverWorkLogs");

            migrationBuilder.DropTable(
                name: "TransportUnit");

            migrationBuilder.DropIndex(
                name: "IX_DriverWorkLogs_LargeGoodsVehicleVehicleId",
                table: "DriverWorkLogs");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "LargeGoodsVehicleId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "TachoExpiryDate",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "LargeGoodsVehicleVehicleId",
                table: "DriverWorkLogs");

            migrationBuilder.RenameColumn(
                name: "TransportUnitId",
                table: "DriverWorkLogs",
                newName: "LargeGoodsVehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_DriverWorkLogs_TransportUnitId",
                table: "DriverWorkLogs",
                newName: "IX_DriverWorkLogs_LargeGoodsVehicleId");

            migrationBuilder.CreateTable(
                name: "LargeGoodsVehicles",
                columns: table => new
                {
                    LargeGoodsVehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrailerId = table.Column<int>(type: "int", nullable: true),
                    VehicleId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationNumberTrailer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TachoExpiryDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LargeGoodsVehicles", x => x.LargeGoodsVehicleId);
                    table.ForeignKey(
                        name: "FK_LargeGoodsVehicles_Vehicles_TrailerId",
                        column: x => x.TrailerId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId");
                    table.ForeignKey(
                        name: "FK_LargeGoodsVehicles_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LargeGoodsVehicles_TrailerId",
                table: "LargeGoodsVehicles",
                column: "TrailerId");

            migrationBuilder.CreateIndex(
                name: "IX_LargeGoodsVehicles_VehicleId",
                table: "LargeGoodsVehicles",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverWorkLogs_LargeGoodsVehicles_LargeGoodsVehicleId",
                table: "DriverWorkLogs",
                column: "LargeGoodsVehicleId",
                principalTable: "LargeGoodsVehicles",
                principalColumn: "LargeGoodsVehicleId");
        }
    }
}

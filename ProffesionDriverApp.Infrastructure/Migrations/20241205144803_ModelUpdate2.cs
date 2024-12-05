using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfessionDriverApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModelUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LargeGoodsVehicles_Vehicles_VehicleId",
                table: "LargeGoodsVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Employees_EmployeeId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_EmployeeId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "LargeGoodsVehicles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "LargeGoodsVehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumberTrailer",
                table: "LargeGoodsVehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_LargeGoodsVehicles_Vehicles_VehicleId",
                table: "LargeGoodsVehicles",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LargeGoodsVehicles_Vehicles_VehicleId",
                table: "LargeGoodsVehicles");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "LargeGoodsVehicles");

            migrationBuilder.DropColumn(
                name: "RegistrationNumberTrailer",
                table: "LargeGoodsVehicles");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Vehicles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EntityId",
                table: "Vehicles",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "LargeGoodsVehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_EmployeeId",
                table: "Vehicles",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LargeGoodsVehicles_Vehicles_VehicleId",
                table: "LargeGoodsVehicles",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Employees_EmployeeId",
                table: "Vehicles",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }
    }
}

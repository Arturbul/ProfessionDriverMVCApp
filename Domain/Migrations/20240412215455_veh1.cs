using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class veh1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleInspectionId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleInsuranceId",
                table: "Vehicles");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleInspectionId",
                table: "Vehicles",
                column: "VehicleInspectionId",
                unique: true,
                filter: "[VehicleInspectionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleInsuranceId",
                table: "Vehicles",
                column: "VehicleInsuranceId",
                unique: true,
                filter: "[VehicleInsuranceId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleInspectionId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleInsuranceId",
                table: "Vehicles");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleInspectionId",
                table: "Vehicles",
                column: "VehicleInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleInsuranceId",
                table: "Vehicles",
                column: "VehicleInsuranceId");
        }
    }
}

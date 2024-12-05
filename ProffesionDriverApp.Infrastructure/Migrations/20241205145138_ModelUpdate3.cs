using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfessionDriverApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModelUpdate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LargeGoodsVehicles_Companies_CompanyId",
                table: "LargeGoodsVehicles");

            migrationBuilder.DropIndex(
                name: "IX_LargeGoodsVehicles_CompanyId",
                table: "LargeGoodsVehicles");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Vehicles");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CompanyId",
                table: "Vehicles",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Companies_CompanyId",
                table: "Vehicles",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Companies_CompanyId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_CompanyId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LargeGoodsVehicles_CompanyId",
                table: "LargeGoodsVehicles",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_LargeGoodsVehicles_Companies_CompanyId",
                table: "LargeGoodsVehicles",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

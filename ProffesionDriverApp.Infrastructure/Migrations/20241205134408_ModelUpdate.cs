using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfessionDriverApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumberTrailer",
                table: "DriverWorkLogEntries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DriverId",
                table: "AspNetUsers",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Drivers_DriverId",
                table: "AspNetUsers",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "DriverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Drivers_DriverId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DriverId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RegistrationNumberTrailer",
                table: "DriverWorkLogEntries");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "AspNetUsers");
        }
    }
}

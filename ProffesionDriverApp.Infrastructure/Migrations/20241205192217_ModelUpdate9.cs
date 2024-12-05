using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfessionDriverApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModelUpdate9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrailerBrand",
                table: "TransportUnits",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrailerBrand",
                table: "TransportUnits");
        }
    }
}

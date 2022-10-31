using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaManagement.Infrastructure.Migrations
{
    public partial class addcolumntomovietable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Format",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Format",
                table: "Movies");
        }
    }
}

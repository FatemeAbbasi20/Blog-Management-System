using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeYad_Blog_DataLayer.Migrations
{
    public partial class AddIsSpecialCorrectly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSpecial",
                table: "Categories");

            migrationBuilder.AddColumn<bool>(
                name: "IsSpecial",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSpecial",
                table: "Posts");

            migrationBuilder.AddColumn<bool>(
                name: "IsSpecial",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

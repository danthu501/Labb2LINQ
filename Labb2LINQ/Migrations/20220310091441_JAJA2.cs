using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb2LINQ.Migrations
{
    public partial class JAJA2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fLärare",
                table: "LärareÄmnen");

            migrationBuilder.DropColumn(
                name: "fÄmne",
                table: "LärareÄmnen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fLärare",
                table: "LärareÄmnen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fÄmne",
                table: "LärareÄmnen",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

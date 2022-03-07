using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb2LINQ.Migrations
{
    public partial class UPdatetDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kurs",
                table: "Lärare");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Kurs",
                table: "Lärare",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb2LINQ.Migrations
{
    public partial class Test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ämnen_Lärare_LärareID",
                table: "Ämnen");

            migrationBuilder.DropIndex(
                name: "IX_Ämnen_LärareID",
                table: "Ämnen");

            migrationBuilder.DropColumn(
                name: "LärareID",
                table: "Ämnen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LärareID",
                table: "Ämnen",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ämnen_LärareID",
                table: "Ämnen",
                column: "LärareID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ämnen_Lärare_LärareID",
                table: "Ämnen",
                column: "LärareID",
                principalTable: "Lärare",
                principalColumn: "LärareID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

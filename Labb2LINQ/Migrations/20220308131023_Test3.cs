using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb2LINQ.Migrations
{
    public partial class Test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ÄmneId",
                table: "Lärare",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lärare_ÄmneId",
                table: "Lärare",
                column: "ÄmneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lärare_Ämnen_ÄmneId",
                table: "Lärare",
                column: "ÄmneId",
                principalTable: "Ämnen",
                principalColumn: "ÄmneId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lärare_Ämnen_ÄmneId",
                table: "Lärare");

            migrationBuilder.DropIndex(
                name: "IX_Lärare_ÄmneId",
                table: "Lärare");

            migrationBuilder.DropColumn(
                name: "ÄmneId",
                table: "Lärare");
        }
    }
}

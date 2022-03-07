using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb2LINQ.Migrations
{
    public partial class ByggtOm3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lärare_Kurser_KursId",
                table: "Lärare");

            migrationBuilder.DropIndex(
                name: "IX_Lärare_KursId",
                table: "Lärare");

            migrationBuilder.DropColumn(
                name: "fLärarId",
                table: "Ämnen");

            migrationBuilder.DropColumn(
                name: "KursId",
                table: "Lärare");

            migrationBuilder.AddColumn<int>(
                name: "Kurs",
                table: "Lärare",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LärareID",
                table: "Kurser",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kurser_LärareID",
                table: "Kurser",
                column: "LärareID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kurser_Lärare_LärareID",
                table: "Kurser",
                column: "LärareID",
                principalTable: "Lärare",
                principalColumn: "LärareID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kurser_Lärare_LärareID",
                table: "Kurser");

            migrationBuilder.DropIndex(
                name: "IX_Kurser_LärareID",
                table: "Kurser");

            migrationBuilder.DropColumn(
                name: "Kurs",
                table: "Lärare");

            migrationBuilder.DropColumn(
                name: "LärareID",
                table: "Kurser");

            migrationBuilder.AddColumn<int>(
                name: "fLärarId",
                table: "Ämnen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KursId",
                table: "Lärare",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lärare_KursId",
                table: "Lärare",
                column: "KursId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lärare_Kurser_KursId",
                table: "Lärare",
                column: "KursId",
                principalTable: "Kurser",
                principalColumn: "KursId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

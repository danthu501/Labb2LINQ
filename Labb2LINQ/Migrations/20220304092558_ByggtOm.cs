using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb2LINQ.Migrations
{
    public partial class ByggtOm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kurser_Studenter_StudentId",
                table: "Kurser");

            migrationBuilder.DropIndex(
                name: "IX_Kurser_StudentId",
                table: "Kurser");

            migrationBuilder.DropColumn(
                name: "fLärareID",
                table: "Ämnen");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Kurser");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Ämnen",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fLärarIdLärareID",
                table: "Ämnen",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KursenKursId",
                table: "Studenter",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KursId",
                table: "Lärare",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ämnen_StudentId",
                table: "Ämnen",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Ämnen_fLärarIdLärareID",
                table: "Ämnen",
                column: "fLärarIdLärareID");

            migrationBuilder.CreateIndex(
                name: "IX_Studenter_KursenKursId",
                table: "Studenter",
                column: "KursenKursId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Studenter_Kurser_KursenKursId",
                table: "Studenter",
                column: "KursenKursId",
                principalTable: "Kurser",
                principalColumn: "KursId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ämnen_Studenter_StudentId",
                table: "Ämnen",
                column: "StudentId",
                principalTable: "Studenter",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ämnen_Lärare_fLärarIdLärareID",
                table: "Ämnen",
                column: "fLärarIdLärareID",
                principalTable: "Lärare",
                principalColumn: "LärareID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lärare_Kurser_KursId",
                table: "Lärare");

            migrationBuilder.DropForeignKey(
                name: "FK_Studenter_Kurser_KursenKursId",
                table: "Studenter");

            migrationBuilder.DropForeignKey(
                name: "FK_Ämnen_Studenter_StudentId",
                table: "Ämnen");

            migrationBuilder.DropForeignKey(
                name: "FK_Ämnen_Lärare_fLärarIdLärareID",
                table: "Ämnen");

            migrationBuilder.DropIndex(
                name: "IX_Ämnen_StudentId",
                table: "Ämnen");

            migrationBuilder.DropIndex(
                name: "IX_Ämnen_fLärarIdLärareID",
                table: "Ämnen");

            migrationBuilder.DropIndex(
                name: "IX_Studenter_KursenKursId",
                table: "Studenter");

            migrationBuilder.DropIndex(
                name: "IX_Lärare_KursId",
                table: "Lärare");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Ämnen");

            migrationBuilder.DropColumn(
                name: "fLärarIdLärareID",
                table: "Ämnen");

            migrationBuilder.DropColumn(
                name: "KursenKursId",
                table: "Studenter");

            migrationBuilder.DropColumn(
                name: "KursId",
                table: "Lärare");

            migrationBuilder.AddColumn<int>(
                name: "fLärareID",
                table: "Ämnen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Kurser",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kurser_StudentId",
                table: "Kurser",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kurser_Studenter_StudentId",
                table: "Kurser",
                column: "StudentId",
                principalTable: "Studenter",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

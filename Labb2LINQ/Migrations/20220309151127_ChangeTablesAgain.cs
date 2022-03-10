using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb2LINQ.Migrations
{
    public partial class ChangeTablesAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lärare_Ämnen_ÄmneId",
                table: "Lärare");

            migrationBuilder.DropForeignKey(
                name: "FK_Studenter_Kurser_KursenKursId",
                table: "Studenter");

            migrationBuilder.DropIndex(
                name: "IX_Studenter_KursenKursId",
                table: "Studenter");

            migrationBuilder.DropIndex(
                name: "IX_Lärare_ÄmneId",
                table: "Lärare");

            migrationBuilder.DropColumn(
                name: "KursenKursId",
                table: "Studenter");

            migrationBuilder.DropColumn(
                name: "ÄmneId",
                table: "Lärare");

            migrationBuilder.AddColumn<int>(
                name: "LärareID",
                table: "Ämnen",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KursId",
                table: "Studenter",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fKursenId",
                table: "Studenter",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ämnen_LärareID",
                table: "Ämnen",
                column: "LärareID");

            migrationBuilder.CreateIndex(
                name: "IX_Studenter_KursId",
                table: "Studenter",
                column: "KursId");

            migrationBuilder.AddForeignKey(
                name: "FK_Studenter_Kurser_KursId",
                table: "Studenter",
                column: "KursId",
                principalTable: "Kurser",
                principalColumn: "KursId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ämnen_Lärare_LärareID",
                table: "Ämnen",
                column: "LärareID",
                principalTable: "Lärare",
                principalColumn: "LärareID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studenter_Kurser_KursId",
                table: "Studenter");

            migrationBuilder.DropForeignKey(
                name: "FK_Ämnen_Lärare_LärareID",
                table: "Ämnen");

            migrationBuilder.DropIndex(
                name: "IX_Ämnen_LärareID",
                table: "Ämnen");

            migrationBuilder.DropIndex(
                name: "IX_Studenter_KursId",
                table: "Studenter");

            migrationBuilder.DropColumn(
                name: "LärareID",
                table: "Ämnen");

            migrationBuilder.DropColumn(
                name: "KursId",
                table: "Studenter");

            migrationBuilder.DropColumn(
                name: "fKursenId",
                table: "Studenter");

            migrationBuilder.AddColumn<int>(
                name: "KursenKursId",
                table: "Studenter",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ÄmneId",
                table: "Lärare",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Studenter_KursenKursId",
                table: "Studenter",
                column: "KursenKursId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Studenter_Kurser_KursenKursId",
                table: "Studenter",
                column: "KursenKursId",
                principalTable: "Kurser",
                principalColumn: "KursId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

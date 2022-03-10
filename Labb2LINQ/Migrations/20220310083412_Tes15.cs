using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb2LINQ.Migrations
{
    public partial class Tes15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kurser_Lärare_LärareID",
                table: "Kurser");

            migrationBuilder.DropForeignKey(
                name: "FK_Ämnen_Lärare_LärareID",
                table: "Ämnen");

            migrationBuilder.DropIndex(
                name: "IX_Ämnen_LärareID",
                table: "Ämnen");

            migrationBuilder.DropIndex(
                name: "IX_Kurser_LärareID",
                table: "Kurser");

            migrationBuilder.DropColumn(
                name: "LärareID",
                table: "Ämnen");

            migrationBuilder.DropColumn(
                name: "LärareID",
                table: "Kurser");

            migrationBuilder.AddColumn<int>(
                name: "KursId",
                table: "Studenter",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KursId",
                table: "KursÄmne",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Studenter_KursId",
                table: "Studenter",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_KursÄmne_KursId",
                table: "KursÄmne",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_KursÄmne_fÄmneId",
                table: "KursÄmne",
                column: "fÄmneId");

            migrationBuilder.AddForeignKey(
                name: "FK_KursÄmne_Kurser_KursId",
                table: "KursÄmne",
                column: "KursId",
                principalTable: "Kurser",
                principalColumn: "KursId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KursÄmne_Ämnen_fÄmneId",
                table: "KursÄmne",
                column: "fÄmneId",
                principalTable: "Ämnen",
                principalColumn: "ÄmneId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Studenter_Kurser_KursId",
                table: "Studenter",
                column: "KursId",
                principalTable: "Kurser",
                principalColumn: "KursId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KursÄmne_Kurser_KursId",
                table: "KursÄmne");

            migrationBuilder.DropForeignKey(
                name: "FK_KursÄmne_Ämnen_fÄmneId",
                table: "KursÄmne");

            migrationBuilder.DropForeignKey(
                name: "FK_Studenter_Kurser_KursId",
                table: "Studenter");

            migrationBuilder.DropIndex(
                name: "IX_Studenter_KursId",
                table: "Studenter");

            migrationBuilder.DropIndex(
                name: "IX_KursÄmne_KursId",
                table: "KursÄmne");

            migrationBuilder.DropIndex(
                name: "IX_KursÄmne_fÄmneId",
                table: "KursÄmne");

            migrationBuilder.DropColumn(
                name: "KursId",
                table: "Studenter");

            migrationBuilder.DropColumn(
                name: "KursId",
                table: "KursÄmne");

            migrationBuilder.AddColumn<int>(
                name: "LärareID",
                table: "Ämnen",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LärareID",
                table: "Kurser",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ämnen_LärareID",
                table: "Ämnen",
                column: "LärareID");

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

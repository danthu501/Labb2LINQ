using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb2LINQ.Migrations
{
    public partial class JAJA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KursÄmne_Kurser_fKursKursId",
                table: "KursÄmne");

            migrationBuilder.DropIndex(
                name: "IX_KursÄmne_fKursKursId",
                table: "KursÄmne");

            migrationBuilder.DropColumn(
                name: "fCourseId",
                table: "KursÄmne");

            migrationBuilder.DropColumn(
                name: "fKursKursId",
                table: "KursÄmne");

            migrationBuilder.AddColumn<int>(
                name: "fKurs",
                table: "KursÄmne",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fKurserKursId",
                table: "KursÄmne",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KursÄmne_fKurserKursId",
                table: "KursÄmne",
                column: "fKurserKursId");

            migrationBuilder.AddForeignKey(
                name: "FK_KursÄmne_Kurser_fKurserKursId",
                table: "KursÄmne",
                column: "fKurserKursId",
                principalTable: "Kurser",
                principalColumn: "KursId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KursÄmne_Kurser_fKurserKursId",
                table: "KursÄmne");

            migrationBuilder.DropIndex(
                name: "IX_KursÄmne_fKurserKursId",
                table: "KursÄmne");

            migrationBuilder.DropColumn(
                name: "fKurs",
                table: "KursÄmne");

            migrationBuilder.DropColumn(
                name: "fKurserKursId",
                table: "KursÄmne");

            migrationBuilder.AddColumn<int>(
                name: "fCourseId",
                table: "KursÄmne",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fKursKursId",
                table: "KursÄmne",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KursÄmne_fKursKursId",
                table: "KursÄmne",
                column: "fKursKursId");

            migrationBuilder.AddForeignKey(
                name: "FK_KursÄmne_Kurser_fKursKursId",
                table: "KursÄmne",
                column: "fKursKursId",
                principalTable: "Kurser",
                principalColumn: "KursId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

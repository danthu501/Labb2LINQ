using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb2LINQ.Migrations
{
    public partial class ChangeTablesAgain5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KursÄmne_Kurser_KursId",
                table: "KursÄmne");

            migrationBuilder.DropForeignKey(
                name: "FK_KursÄmne_Ämnen_fÄmneId",
                table: "KursÄmne");

            migrationBuilder.DropIndex(
                name: "IX_KursÄmne_KursId",
                table: "KursÄmne");

            migrationBuilder.DropIndex(
                name: "IX_KursÄmne_fÄmneId",
                table: "KursÄmne");

            migrationBuilder.DropColumn(
                name: "KursId",
                table: "KursÄmne");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KursId",
                table: "KursÄmne",
                type: "int",
                nullable: true);

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
        }
    }
}

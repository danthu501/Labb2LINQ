using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb2LINQ.Migrations
{
    public partial class JAJA3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KursÄmne_Ämnen_fÄmneId",
                table: "KursÄmne");

            migrationBuilder.DropIndex(
                name: "IX_KursÄmne_fÄmneId",
                table: "KursÄmne");

            migrationBuilder.DropColumn(
                name: "fKurs",
                table: "KursÄmne");

            migrationBuilder.DropColumn(
                name: "fÄmneId",
                table: "KursÄmne");

            migrationBuilder.AddColumn<int>(
                name: "fÄmneÄmneId",
                table: "KursÄmne",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KursÄmne_fÄmneÄmneId",
                table: "KursÄmne",
                column: "fÄmneÄmneId");

            migrationBuilder.AddForeignKey(
                name: "FK_KursÄmne_Ämnen_fÄmneÄmneId",
                table: "KursÄmne",
                column: "fÄmneÄmneId",
                principalTable: "Ämnen",
                principalColumn: "ÄmneId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KursÄmne_Ämnen_fÄmneÄmneId",
                table: "KursÄmne");

            migrationBuilder.DropIndex(
                name: "IX_KursÄmne_fÄmneÄmneId",
                table: "KursÄmne");

            migrationBuilder.DropColumn(
                name: "fÄmneÄmneId",
                table: "KursÄmne");

            migrationBuilder.AddColumn<int>(
                name: "fKurs",
                table: "KursÄmne",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fÄmneId",
                table: "KursÄmne",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_KursÄmne_fÄmneId",
                table: "KursÄmne",
                column: "fÄmneId");

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

using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb2LINQ.Migrations
{
    public partial class UPdatetDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ämnen_Studenter_StudentId",
                table: "Ämnen");

            migrationBuilder.DropIndex(
                name: "IX_Ämnen_StudentId",
                table: "Ämnen");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Ämnen");

            migrationBuilder.AddColumn<int>(
                name: "ÄmneId",
                table: "Studenter",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Studenter_ÄmneId",
                table: "Studenter",
                column: "ÄmneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Studenter_Ämnen_ÄmneId",
                table: "Studenter",
                column: "ÄmneId",
                principalTable: "Ämnen",
                principalColumn: "ÄmneId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studenter_Ämnen_ÄmneId",
                table: "Studenter");

            migrationBuilder.DropIndex(
                name: "IX_Studenter_ÄmneId",
                table: "Studenter");

            migrationBuilder.DropColumn(
                name: "ÄmneId",
                table: "Studenter");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Ämnen",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ämnen_StudentId",
                table: "Ämnen",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ämnen_Studenter_StudentId",
                table: "Ämnen",
                column: "StudentId",
                principalTable: "Studenter",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

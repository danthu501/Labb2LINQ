using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb2LINQ.Migrations
{
    public partial class AddedÄmneToStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "ÄmnenÄmneId",
                table: "Studenter",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Studenter_ÄmnenÄmneId",
                table: "Studenter",
                column: "ÄmnenÄmneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Studenter_Ämnen_ÄmnenÄmneId",
                table: "Studenter",
                column: "ÄmnenÄmneId",
                principalTable: "Ämnen",
                principalColumn: "ÄmneId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studenter_Ämnen_ÄmnenÄmneId",
                table: "Studenter");

            migrationBuilder.DropIndex(
                name: "IX_Studenter_ÄmnenÄmneId",
                table: "Studenter");

            migrationBuilder.DropColumn(
                name: "ÄmnenÄmneId",
                table: "Studenter");

            migrationBuilder.AddColumn<int>(
                name: "ÄmneId",
                table: "Studenter",
                type: "int",
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
    }
}

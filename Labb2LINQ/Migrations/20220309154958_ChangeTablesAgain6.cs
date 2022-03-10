using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb2LINQ.Migrations
{
    public partial class ChangeTablesAgain6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studenter_Kurser_KursId",
                table: "Studenter");

            migrationBuilder.DropIndex(
                name: "IX_Studenter_KursId",
                table: "Studenter");

            migrationBuilder.DropColumn(
                name: "KursId",
                table: "Studenter");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KursId",
                table: "Studenter",
                type: "int",
                nullable: true);

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
        }
    }
}

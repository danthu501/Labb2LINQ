using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb2LINQ.Migrations
{
    public partial class AddedLärareToStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LärareID",
                table: "Studenter",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Studenter_LärareID",
                table: "Studenter",
                column: "LärareID");

            migrationBuilder.AddForeignKey(
                name: "FK_Studenter_Lärare_LärareID",
                table: "Studenter",
                column: "LärareID",
                principalTable: "Lärare",
                principalColumn: "LärareID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studenter_Lärare_LärareID",
                table: "Studenter");

            migrationBuilder.DropIndex(
                name: "IX_Studenter_LärareID",
                table: "Studenter");

            migrationBuilder.DropColumn(
                name: "LärareID",
                table: "Studenter");
        }
    }
}

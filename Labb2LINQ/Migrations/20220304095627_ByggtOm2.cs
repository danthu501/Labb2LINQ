using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb2LINQ.Migrations
{
    public partial class ByggtOm2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ämnen_Lärare_fLärarIdLärareID",
                table: "Ämnen");

            migrationBuilder.DropIndex(
                name: "IX_Ämnen_fLärarIdLärareID",
                table: "Ämnen");

            migrationBuilder.DropColumn(
                name: "fLärarIdLärareID",
                table: "Ämnen");

            migrationBuilder.AddColumn<int>(
                name: "LärareID",
                table: "Ämnen",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fLärarId",
                table: "Ämnen",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ämnen_LärareID",
                table: "Ämnen",
                column: "LärareID");

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
                name: "FK_Ämnen_Lärare_LärareID",
                table: "Ämnen");

            migrationBuilder.DropIndex(
                name: "IX_Ämnen_LärareID",
                table: "Ämnen");

            migrationBuilder.DropColumn(
                name: "LärareID",
                table: "Ämnen");

            migrationBuilder.DropColumn(
                name: "fLärarId",
                table: "Ämnen");

            migrationBuilder.AddColumn<int>(
                name: "fLärarIdLärareID",
                table: "Ämnen",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ämnen_fLärarIdLärareID",
                table: "Ämnen",
                column: "fLärarIdLärareID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ämnen_Lärare_fLärarIdLärareID",
                table: "Ämnen",
                column: "fLärarIdLärareID",
                principalTable: "Lärare",
                principalColumn: "LärareID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

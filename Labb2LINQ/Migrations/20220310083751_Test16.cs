using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb2LINQ.Migrations
{
    public partial class Test16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KursÄmne_Kurser_KursId",
                table: "KursÄmne");

            migrationBuilder.DropIndex(
                name: "IX_KursÄmne_KursId",
                table: "KursÄmne");

            migrationBuilder.DropColumn(
                name: "KursId",
                table: "KursÄmne");

            migrationBuilder.AddColumn<int>(
                name: "fKursKursId",
                table: "KursÄmne",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LärareÄmnen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fLärare = table.Column<int>(nullable: false),
                    fÄmne = table.Column<int>(nullable: false),
                    LärareID = table.Column<int>(nullable: true),
                    ÄmneId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LärareÄmnen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LärareÄmnen_Lärare_LärareID",
                        column: x => x.LärareID,
                        principalTable: "Lärare",
                        principalColumn: "LärareID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LärareÄmnen_Ämnen_ÄmneId",
                        column: x => x.ÄmneId,
                        principalTable: "Ämnen",
                        principalColumn: "ÄmneId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KursÄmne_fKursKursId",
                table: "KursÄmne",
                column: "fKursKursId");

            migrationBuilder.CreateIndex(
                name: "IX_LärareÄmnen_LärareID",
                table: "LärareÄmnen",
                column: "LärareID");

            migrationBuilder.CreateIndex(
                name: "IX_LärareÄmnen_ÄmneId",
                table: "LärareÄmnen",
                column: "ÄmneId");

            migrationBuilder.AddForeignKey(
                name: "FK_KursÄmne_Kurser_fKursKursId",
                table: "KursÄmne",
                column: "fKursKursId",
                principalTable: "Kurser",
                principalColumn: "KursId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KursÄmne_Kurser_fKursKursId",
                table: "KursÄmne");

            migrationBuilder.DropTable(
                name: "LärareÄmnen");

            migrationBuilder.DropIndex(
                name: "IX_KursÄmne_fKursKursId",
                table: "KursÄmne");

            migrationBuilder.DropColumn(
                name: "fKursKursId",
                table: "KursÄmne");

            migrationBuilder.AddColumn<int>(
                name: "KursId",
                table: "KursÄmne",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KursÄmne_KursId",
                table: "KursÄmne",
                column: "KursId");

            migrationBuilder.AddForeignKey(
                name: "FK_KursÄmne_Kurser_KursId",
                table: "KursÄmne",
                column: "KursId",
                principalTable: "Kurser",
                principalColumn: "KursId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb2LINQ.Migrations
{
    public partial class ChangeTablesAgain4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KursÄmne",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fÄmneId = table.Column<int>(nullable: false),
                    fCourseId = table.Column<int>(nullable: false),
                    KursId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KursÄmne", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KursÄmne_Kurser_KursId",
                        column: x => x.KursId,
                        principalTable: "Kurser",
                        principalColumn: "KursId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KursÄmne_Ämnen_fÄmneId",
                        column: x => x.fÄmneId,
                        principalTable: "Ämnen",
                        principalColumn: "ÄmneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KursÄmne_KursId",
                table: "KursÄmne",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_KursÄmne_fÄmneId",
                table: "KursÄmne",
                column: "fÄmneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KursÄmne");
        }
    }
}

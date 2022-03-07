using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb2LINQ.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lärare",
                columns: table => new
                {
                    LärareID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Förnamn = table.Column<string>(nullable: true),
                    Efternamn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lärare", x => x.LärareID);
                });

            migrationBuilder.CreateTable(
                name: "Studenter",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Förnamn = table.Column<string>(nullable: true),
                    Efternamn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenter", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Ämnen",
                columns: table => new
                {
                    ÄmneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ÄmneNamn = table.Column<string>(nullable: true),
                    LärareID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ämnen", x => x.ÄmneId);
                    table.ForeignKey(
                        name: "FK_Ämnen_Lärare_LärareID",
                        column: x => x.LärareID,
                        principalTable: "Lärare",
                        principalColumn: "LärareID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kurser",
                columns: table => new
                {
                    KursId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KursNamn = table.Column<string>(nullable: true),
                    StudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurser", x => x.KursId);
                    table.ForeignKey(
                        name: "FK_Kurser_Studenter_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Studenter",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kurser_StudentId",
                table: "Kurser",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Ämnen_LärareID",
                table: "Ämnen",
                column: "LärareID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kurser");

            migrationBuilder.DropTable(
                name: "Ämnen");

            migrationBuilder.DropTable(
                name: "Studenter");

            migrationBuilder.DropTable(
                name: "Lärare");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamensarbeteNy.Migrations
{
    public partial class AddChildKategoriToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kategorier_Kategorier_ÖverkategoriId",
                table: "Kategorier");

            migrationBuilder.DropIndex(
                name: "IX_Kategorier_ÖverkategoriId",
                table: "Kategorier");

            migrationBuilder.DropColumn(
                name: "ÖverkategoriId",
                table: "Kategorier");

            migrationBuilder.CreateTable(
                name: "ChildKategorier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beskrivning = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildKategorier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildKategorier_Kategorier_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategorier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildKategorier_KategoriId",
                table: "ChildKategorier",
                column: "KategoriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildKategorier");

            migrationBuilder.AddColumn<int>(
                name: "ÖverkategoriId",
                table: "Kategorier",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kategorier_ÖverkategoriId",
                table: "Kategorier",
                column: "ÖverkategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kategorier_Kategorier_ÖverkategoriId",
                table: "Kategorier",
                column: "ÖverkategoriId",
                principalTable: "Kategorier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

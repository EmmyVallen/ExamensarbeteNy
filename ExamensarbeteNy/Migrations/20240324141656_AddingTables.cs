using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamensarbeteNy.Migrations
{
    public partial class AddingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Användare",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Användarnamn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lösenord = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Användare", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategorier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beskrivning = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kundkorgar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnvändarId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kundkorgar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kundkorgar_Användare_AnvändarId",
                        column: x => x.AnvändarId,
                        principalTable: "Användare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produkter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beskrivning = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pris = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BildUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    AnvändarId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnvändareId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    KundkorgId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produkter_Användare_AnvändareId",
                        column: x => x.AnvändareId,
                        principalTable: "Användare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produkter_Kategorier_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategorier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produkter_Kundkorgar_KundkorgId",
                        column: x => x.KundkorgId,
                        principalTable: "Kundkorgar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bevakningar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnvändarId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnvändareId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProduktId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bevakningar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bevakningar_Användare_AnvändareId",
                        column: x => x.AnvändareId,
                        principalTable: "Användare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bevakningar_Produkter_ProduktId",
                        column: x => x.ProduktId,
                        principalTable: "Produkter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bevakningar_AnvändareId",
                table: "Bevakningar",
                column: "AnvändareId");

            migrationBuilder.CreateIndex(
                name: "IX_Bevakningar_ProduktId",
                table: "Bevakningar",
                column: "ProduktId");

            migrationBuilder.CreateIndex(
                name: "IX_Kundkorgar_AnvändarId",
                table: "Kundkorgar",
                column: "AnvändarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produkter_AnvändareId",
                table: "Produkter",
                column: "AnvändareId");

            migrationBuilder.CreateIndex(
                name: "IX_Produkter_KategoriId",
                table: "Produkter",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Produkter_KundkorgId",
                table: "Produkter",
                column: "KundkorgId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bevakningar");

            migrationBuilder.DropTable(
                name: "Produkter");

            migrationBuilder.DropTable(
                name: "Kategorier");

            migrationBuilder.DropTable(
                name: "Kundkorgar");

            migrationBuilder.DropTable(
                name: "Användare");
        }
    }
}

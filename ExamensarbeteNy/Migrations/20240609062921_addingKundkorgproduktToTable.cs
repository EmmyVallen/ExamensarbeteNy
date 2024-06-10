using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamensarbeteNy.Migrations
{
    public partial class addingKundkorgproduktToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produkter_Kundkorgar_KundkorgId",
                table: "Produkter");

            migrationBuilder.DropIndex(
                name: "IX_Produkter_KundkorgId",
                table: "Produkter");

            migrationBuilder.DropColumn(
                name: "KundkorgId",
                table: "Produkter");

            migrationBuilder.CreateTable(
                name: "KundkorgProdukt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProduktId = table.Column<int>(type: "int", nullable: false),
                    KundkorgId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KundkorgProdukt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KundkorgProdukt_Kundkorgar_KundkorgId",
                        column: x => x.KundkorgId,
                        principalTable: "Kundkorgar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KundkorgProdukt_Produkter_ProduktId",
                        column: x => x.ProduktId,
                        principalTable: "Produkter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KundkorgProdukt_KundkorgId",
                table: "KundkorgProdukt",
                column: "KundkorgId");

            migrationBuilder.CreateIndex(
                name: "IX_KundkorgProdukt_ProduktId",
                table: "KundkorgProdukt",
                column: "ProduktId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KundkorgProdukt");

            migrationBuilder.AddColumn<int>(
                name: "KundkorgId",
                table: "Produkter",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produkter_KundkorgId",
                table: "Produkter",
                column: "KundkorgId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produkter_Kundkorgar_KundkorgId",
                table: "Produkter",
                column: "KundkorgId",
                principalTable: "Kundkorgar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamensarbeteNy.Migrations
{
    public partial class aa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KundkorgProdukt_Kundkorgar_KundkorgId",
                table: "KundkorgProdukt");

            migrationBuilder.DropForeignKey(
                name: "FK_KundkorgProdukt_Produkter_ProduktId",
                table: "KundkorgProdukt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KundkorgProdukt",
                table: "KundkorgProdukt");

            migrationBuilder.RenameTable(
                name: "KundkorgProdukt",
                newName: "KundkorgProdukter");

            migrationBuilder.RenameIndex(
                name: "IX_KundkorgProdukt_ProduktId",
                table: "KundkorgProdukter",
                newName: "IX_KundkorgProdukter_ProduktId");

            migrationBuilder.RenameIndex(
                name: "IX_KundkorgProdukt_KundkorgId",
                table: "KundkorgProdukter",
                newName: "IX_KundkorgProdukter_KundkorgId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KundkorgProdukter",
                table: "KundkorgProdukter",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KundkorgProdukter_Kundkorgar_KundkorgId",
                table: "KundkorgProdukter",
                column: "KundkorgId",
                principalTable: "Kundkorgar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KundkorgProdukter_Produkter_ProduktId",
                table: "KundkorgProdukter",
                column: "ProduktId",
                principalTable: "Produkter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KundkorgProdukter_Kundkorgar_KundkorgId",
                table: "KundkorgProdukter");

            migrationBuilder.DropForeignKey(
                name: "FK_KundkorgProdukter_Produkter_ProduktId",
                table: "KundkorgProdukter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KundkorgProdukter",
                table: "KundkorgProdukter");

            migrationBuilder.RenameTable(
                name: "KundkorgProdukter",
                newName: "KundkorgProdukt");

            migrationBuilder.RenameIndex(
                name: "IX_KundkorgProdukter_ProduktId",
                table: "KundkorgProdukt",
                newName: "IX_KundkorgProdukt_ProduktId");

            migrationBuilder.RenameIndex(
                name: "IX_KundkorgProdukter_KundkorgId",
                table: "KundkorgProdukt",
                newName: "IX_KundkorgProdukt_KundkorgId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KundkorgProdukt",
                table: "KundkorgProdukt",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KundkorgProdukt_Kundkorgar_KundkorgId",
                table: "KundkorgProdukt",
                column: "KundkorgId",
                principalTable: "Kundkorgar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KundkorgProdukt_Produkter_ProduktId",
                table: "KundkorgProdukt",
                column: "ProduktId",
                principalTable: "Produkter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamensarbeteNy.Migrations
{
    public partial class AddingChildToProdukt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChildKategoriId",
                table: "Produkter",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produkter_ChildKategoriId",
                table: "Produkter",
                column: "ChildKategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produkter_ChildKategorier_ChildKategoriId",
                table: "Produkter",
                column: "ChildKategoriId",
                principalTable: "ChildKategorier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produkter_ChildKategorier_ChildKategoriId",
                table: "Produkter");

            migrationBuilder.DropIndex(
                name: "IX_Produkter_ChildKategoriId",
                table: "Produkter");

            migrationBuilder.DropColumn(
                name: "ChildKategoriId",
                table: "Produkter");
        }
    }
}

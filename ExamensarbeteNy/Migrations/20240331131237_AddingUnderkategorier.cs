using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamensarbeteNy.Migrations
{
    public partial class AddingUnderkategorier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}

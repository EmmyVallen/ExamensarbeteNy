using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamensarbeteNy.Migrations
{
    public partial class TABORTANVÄNDARE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bevakningar_Användare_AnvändareId",
                table: "Bevakningar");

            migrationBuilder.DropForeignKey(
                name: "FK_Kundkorgar_Användare_AnvändarId",
                table: "Kundkorgar");

            migrationBuilder.DropForeignKey(
                name: "FK_Produkter_Användare_AnvändareId",
                table: "Produkter");

            migrationBuilder.DropTable(
                name: "Användare");

            migrationBuilder.DropIndex(
                name: "IX_Produkter_AnvändareId",
                table: "Produkter");

            migrationBuilder.DropIndex(
                name: "IX_Kundkorgar_AnvändarId",
                table: "Kundkorgar");

            migrationBuilder.DropIndex(
                name: "IX_Bevakningar_AnvändareId",
                table: "Bevakningar");

            migrationBuilder.DropColumn(
                name: "AnvändarId",
                table: "Produkter");

            migrationBuilder.DropColumn(
                name: "AnvändareId",
                table: "Produkter");

            migrationBuilder.DropColumn(
                name: "AnvändarId",
                table: "Kundkorgar");

            migrationBuilder.DropColumn(
                name: "AnvändarId",
                table: "Bevakningar");

            migrationBuilder.DropColumn(
                name: "AnvändareId",
                table: "Bevakningar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnvändarId",
                table: "Produkter",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AnvändareId",
                table: "Produkter",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnvändarId",
                table: "Kundkorgar",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AnvändarId",
                table: "Bevakningar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnvändareId",
                table: "Bevakningar",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_Produkter_AnvändareId",
                table: "Produkter",
                column: "AnvändareId");

            migrationBuilder.CreateIndex(
                name: "IX_Kundkorgar_AnvändarId",
                table: "Kundkorgar",
                column: "AnvändarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bevakningar_AnvändareId",
                table: "Bevakningar",
                column: "AnvändareId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bevakningar_Användare_AnvändareId",
                table: "Bevakningar",
                column: "AnvändareId",
                principalTable: "Användare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kundkorgar_Användare_AnvändarId",
                table: "Kundkorgar",
                column: "AnvändarId",
                principalTable: "Användare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produkter_Användare_AnvändareId",
                table: "Produkter",
                column: "AnvändareId",
                principalTable: "Användare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

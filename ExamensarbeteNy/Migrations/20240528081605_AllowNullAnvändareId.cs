using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamensarbeteNy.Migrations
{
    public partial class AllowNullAnvändareId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
    name: "AnvändareId",
    table: "Bevakningar",
    nullable: true,
    oldClrType: typeof(int),
    oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<int>(
        name: "AnvändareId",
        table: "Bevakningar",
        nullable: false,
        oldClrType: typeof(int),
        oldType: "int",
        oldNullable: true);
        }
    }
}

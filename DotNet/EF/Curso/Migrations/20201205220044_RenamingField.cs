using Microsoft.EntityFrameworkCore.Migrations;

namespace DominadoEFCore.Migrations
{
    public partial class RenamingField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Funcionarios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

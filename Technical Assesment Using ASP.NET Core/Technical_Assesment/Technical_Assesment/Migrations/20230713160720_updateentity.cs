using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Technical_Assesment.Migrations
{
    public partial class updateentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

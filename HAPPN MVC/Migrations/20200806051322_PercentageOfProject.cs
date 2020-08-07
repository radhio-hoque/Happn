using Microsoft.EntityFrameworkCore.Migrations;

namespace HAPPAN_MVC.Migrations
{
    public partial class PercentageOfProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Label",
                table: "Tasks");

            migrationBuilder.AddColumn<float>(
                name: "PercentageOfProject",
                table: "Tasks",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PercentageOfProject",
                table: "Tasks");

            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

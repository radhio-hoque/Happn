using Microsoft.EntityFrameworkCore.Migrations;

namespace HAPPAN_MVC.Migrations
{
    public partial class ProjectTaskUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskProgress",
                table: "Tasks",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskProgress",
                table: "Tasks");
        }
    }
}

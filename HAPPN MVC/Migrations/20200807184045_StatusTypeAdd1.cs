using Microsoft.EntityFrameworkCore.Migrations;

namespace HAPPAN_MVC.Migrations
{
    public partial class StatusTypeAdd1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PercentageOfProject",
                table: "Tasks",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "PercentageOfProject",
                table: "Tasks",
                type: "real",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}

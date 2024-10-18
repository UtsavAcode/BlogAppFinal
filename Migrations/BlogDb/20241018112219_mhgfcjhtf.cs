using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Migrations.BlogDb
{
    public partial class mhgfcjhtf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScrollPercentage",
                table: "BlogViews");

            migrationBuilder.DropColumn(
                name: "TimeSpentInSeconds",
                table: "BlogViews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScrollPercentage",
                table: "BlogViews",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimeSpentInSeconds",
                table: "BlogViews",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}

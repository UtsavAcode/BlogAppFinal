using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Migrations.BlogDb
{
    public partial class sfsfsdfs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScrollPercentage",
                table: "BlogViews");

            migrationBuilder.DropColumn(
                name: "ViewDurationInSeconds",
                table: "BlogViews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ScrollPercentage",
                table: "BlogViews",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ViewDurationInSeconds",
                table: "BlogViews",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}

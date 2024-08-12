using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Migrations
{
    public partial class noidead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_User_AuthorId",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_AuthorId",
                table: "BlogPosts");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "BlogPosts",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId1",
                table: "BlogPosts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_AuthorId1",
                table: "BlogPosts",
                column: "AuthorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_User_AuthorId1",
                table: "BlogPosts",
                column: "AuthorId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_User_AuthorId1",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_AuthorId1",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "AuthorId1",
                table: "BlogPosts");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "BlogPosts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_AuthorId",
                table: "BlogPosts",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_User_AuthorId",
                table: "BlogPosts",
                column: "AuthorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

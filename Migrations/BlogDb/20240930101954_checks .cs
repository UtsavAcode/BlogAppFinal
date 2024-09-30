using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Migrations.BlogDb
{
    public partial class checks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogView_BlogPosts_BlogPostId",
                table: "BlogView");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogView",
                table: "BlogView");

            migrationBuilder.RenameTable(
                name: "BlogView",
                newName: "BlogViews");

            migrationBuilder.RenameIndex(
                name: "IX_BlogView_BlogPostId",
                table: "BlogViews",
                newName: "IX_BlogViews_BlogPostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogViews",
                table: "BlogViews",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogViews_BlogPosts_BlogPostId",
                table: "BlogViews",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogViews_BlogPosts_BlogPostId",
                table: "BlogViews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogViews",
                table: "BlogViews");

            migrationBuilder.RenameTable(
                name: "BlogViews",
                newName: "BlogView");

            migrationBuilder.RenameIndex(
                name: "IX_BlogViews_BlogPostId",
                table: "BlogView",
                newName: "IX_BlogView_BlogPostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogView",
                table: "BlogView",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogView_BlogPosts_BlogPostId",
                table: "BlogView",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

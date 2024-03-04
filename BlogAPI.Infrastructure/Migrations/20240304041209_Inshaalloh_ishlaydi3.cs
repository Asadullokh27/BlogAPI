using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inshaalloh_ishlaydi3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_BlogPosts_BlogPostId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BlogPostId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BlogPostId1",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "BlogPostId1",
                table: "Comments",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogPostId1",
                table: "Comments",
                column: "BlogPostId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_BlogPosts_BlogPostId1",
                table: "Comments",
                column: "BlogPostId1",
                principalTable: "BlogPosts",
                principalColumn: "Id");
        }
    }
}

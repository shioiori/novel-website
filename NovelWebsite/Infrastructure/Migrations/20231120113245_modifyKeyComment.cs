using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelWebsite.Migrations
{
    public partial class modifyKeyComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentUsers_Comments_ReplyCommentId",
                table: "CommentUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentUsers",
                table: "CommentUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ReplyCommentId",
                table: "CommentUsers",
                type: "nvarchar(36)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(36)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentUsers",
                table: "CommentUsers",
                columns: new[] { "CommentId", "UserId", "InteractionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CommentUsers_Comments_ReplyCommentId",
                table: "CommentUsers",
                column: "ReplyCommentId",
                principalTable: "Comments",
                principalColumn: "CommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentUsers_Comments_ReplyCommentId",
                table: "CommentUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentUsers",
                table: "CommentUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ReplyCommentId",
                table: "CommentUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentUsers",
                table: "CommentUsers",
                columns: new[] { "CommentId", "UserId", "InteractionId", "ReplyCommentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CommentUsers_Comments_ReplyCommentId",
                table: "CommentUsers",
                column: "ReplyCommentId",
                principalTable: "Comments",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

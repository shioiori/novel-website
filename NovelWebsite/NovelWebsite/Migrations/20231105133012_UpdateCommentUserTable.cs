using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelWebsite.Migrations
{
    public partial class UpdateCommentUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_User_Comment_ReplyCommentId",
                table: "Comment_User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment_User",
                table: "Comment_User");

            migrationBuilder.AlterColumn<int>(
                name: "ReplyCommentId",
                table: "Comment_User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment_User",
                table: "Comment_User",
                columns: new[] { "CommentId", "UserId", "InteractType", "ReplyCommentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_User_Comment_ReplyCommentId",
                table: "Comment_User",
                column: "ReplyCommentId",
                principalTable: "Comment",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_User_Comment_ReplyCommentId",
                table: "Comment_User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment_User",
                table: "Comment_User");

            migrationBuilder.AlterColumn<int>(
                name: "ReplyCommentId",
                table: "Comment_User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment_User",
                table: "Comment_User",
                columns: new[] { "CommentId", "UserId", "InteractType" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_User_Comment_ReplyCommentId",
                table: "Comment_User",
                column: "ReplyCommentId",
                principalTable: "Comment",
                principalColumn: "CommentId");
        }
    }
}

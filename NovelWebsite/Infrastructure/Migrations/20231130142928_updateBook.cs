using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelWebsite.Migrations
{
    public partial class updateBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChapterId",
                table: "BookUsers",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Follows",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Recommend",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalChapters",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChapterId",
                table: "BookUsers");

            migrationBuilder.DropColumn(
                name: "Follows",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Recommend",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "TotalChapters",
                table: "Books");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelWebsite.Migrations
{
    public partial class ModifyAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LoginProvide",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginProvide",
                table: "Account");
        }
    }
}

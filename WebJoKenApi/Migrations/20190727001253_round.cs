using Microsoft.EntityFrameworkCore.Migrations;

namespace WebJoKenApi.Migrations
{
    public partial class round : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoundPoints",
                table: "PlayerDB",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoundPoints",
                table: "PlayerDB");
        }
    }
}

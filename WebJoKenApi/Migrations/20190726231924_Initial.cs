using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebJoKenApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerDB",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerDB", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerDB");
        }
    }
}

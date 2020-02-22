using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportUp.Migrations
{
    public partial class AddTeamMaxPlayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TeamCreationDate",
                table: "Teams",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TeamMaxPlayers",
                table: "Teams",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamCreationDate",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamMaxPlayers",
                table: "Teams");
        }
    }
}

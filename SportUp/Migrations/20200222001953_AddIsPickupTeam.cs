using Microsoft.EntityFrameworkCore.Migrations;

namespace SportUp.Migrations
{
    public partial class AddIsPickupTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPickupTeam",
                table: "Teams",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPickupTeam",
                table: "Teams");
        }
    }
}

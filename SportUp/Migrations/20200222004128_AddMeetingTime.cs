using Microsoft.EntityFrameworkCore.Migrations;

namespace SportUp.Migrations
{
    public partial class AddMeetingTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeetingTime",
                table: "Teams",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeetingTime",
                table: "Teams");
        }
    }
}

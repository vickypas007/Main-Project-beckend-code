using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickPickWebApi.Core.Migrations
{
    public partial class statemaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryMasterId",
                table: "stateMasters");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "stateMasters",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "stateMasters");

            migrationBuilder.AddColumn<int>(
                name: "CountryMasterId",
                table: "stateMasters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

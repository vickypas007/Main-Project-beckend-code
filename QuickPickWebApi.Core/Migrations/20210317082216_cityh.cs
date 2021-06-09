using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickPickWebApi.Core.Migrations
{
    public partial class cityh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DistrictName",
                table: "cities");

            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "cities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityName",
                table: "cities");

            migrationBuilder.AddColumn<string>(
                name: "DistrictName",
                table: "cities",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}

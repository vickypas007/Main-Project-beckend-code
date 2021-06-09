using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickPickWebApi.Core.Migrations
{
    public partial class city : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cities_countrys_CountryId",
                table: "cities");

            migrationBuilder.DropForeignKey(
                name: "FK_cities_states_StateId",
                table: "cities");

            migrationBuilder.DropIndex(
                name: "IX_cities_CountryId",
                table: "cities");

            migrationBuilder.DropIndex(
                name: "IX_cities_StateId",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "CountryName",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "StateName",
                table: "cities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "cities",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "cities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CountryName",
                table: "cities",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "cities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StateName",
                table: "cities",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_cities_CountryId",
                table: "cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_cities_StateId",
                table: "cities",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_cities_countrys_CountryId",
                table: "cities",
                column: "CountryId",
                principalTable: "countrys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cities_states_StateId",
                table: "cities",
                column: "StateId",
                principalTable: "states",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickPickWebApi.Core.Migrations
{
    public partial class statetest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stateMasters_countryMasters_CountryMaterId",
                table: "stateMasters");

            migrationBuilder.DropIndex(
                name: "IX_stateMasters_CountryMaterId",
                table: "stateMasters");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "stateMasters");

            migrationBuilder.DropColumn(
                name: "CountryMaterId",
                table: "stateMasters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "stateMasters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryMaterId",
                table: "stateMasters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_stateMasters_CountryMaterId",
                table: "stateMasters",
                column: "CountryMaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_stateMasters_countryMasters_CountryMaterId",
                table: "stateMasters",
                column: "CountryMaterId",
                principalTable: "countryMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickPickWebApi.Core.Migrations
{
    public partial class statett : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryMasterId",
                table: "stateMasters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_stateMasters_CountryMasterId",
                table: "stateMasters",
                column: "CountryMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_stateMasters_countryMasters_CountryMasterId",
                table: "stateMasters",
                column: "CountryMasterId",
                principalTable: "countryMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stateMasters_countryMasters_CountryMasterId",
                table: "stateMasters");

            migrationBuilder.DropIndex(
                name: "IX_stateMasters_CountryMasterId",
                table: "stateMasters");

            migrationBuilder.DropColumn(
                name: "CountryMasterId",
                table: "stateMasters");
        }
    }
}

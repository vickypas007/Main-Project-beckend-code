using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickPickWebApi.Core.Migrations
{
    public partial class changedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_distHubs_districtMasters_DistrictMasterId",
                table: "distHubs");

            migrationBuilder.DropTable(
                name: "districtMasters");

            migrationBuilder.DropTable(
                name: "stateMasters");

            migrationBuilder.DropTable(
                name: "countryMasters");

            migrationBuilder.DropIndex(
                name: "IX_distHubs_DistrictMasterId",
                table: "distHubs");

            migrationBuilder.DropColumn(
                name: "DistrictMasterId",
                table: "distHubs");

            migrationBuilder.AddColumn<string>(
                name: "DistName",
                table: "distHubs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "distHubs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "countrys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CountryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countrys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "states",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StateName = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_states", x => x.Id);
                    table.ForeignKey(
                        name: "FK_states_countrys_CountryId",
                        column: x => x.CountryId,
                        principalTable: "countrys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "districts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DistrictName = table.Column<string>(nullable: true),
                    StateName = table.Column<string>(nullable: true),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_districts_states_StateId",
                        column: x => x.StateId,
                        principalTable: "states",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_distHubs_DistrictId",
                table: "distHubs",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_districts_StateId",
                table: "districts",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_states_CountryId",
                table: "states",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_distHubs_districts_DistrictId",
                table: "distHubs",
                column: "DistrictId",
                principalTable: "districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_distHubs_districts_DistrictId",
                table: "distHubs");

            migrationBuilder.DropTable(
                name: "districts");

            migrationBuilder.DropTable(
                name: "states");

            migrationBuilder.DropTable(
                name: "countrys");

            migrationBuilder.DropIndex(
                name: "IX_distHubs_DistrictId",
                table: "distHubs");

            migrationBuilder.DropColumn(
                name: "DistName",
                table: "distHubs");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "distHubs");

            migrationBuilder.AddColumn<int>(
                name: "DistrictMasterId",
                table: "distHubs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "countryMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CountryName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countryMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "stateMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CountryMasterId = table.Column<int>(type: "int", nullable: false),
                    StateName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stateMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_stateMasters_countryMasters_CountryMasterId",
                        column: x => x.CountryMasterId,
                        principalTable: "countryMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "districtMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DistrictName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    StateMasterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_districtMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_districtMasters_stateMasters_StateMasterId",
                        column: x => x.StateMasterId,
                        principalTable: "stateMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_distHubs_DistrictMasterId",
                table: "distHubs",
                column: "DistrictMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_districtMasters_StateMasterId",
                table: "districtMasters",
                column: "StateMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_stateMasters_CountryMasterId",
                table: "stateMasters",
                column: "CountryMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_distHubs_districtMasters_DistrictMasterId",
                table: "distHubs",
                column: "DistrictMasterId",
                principalTable: "districtMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

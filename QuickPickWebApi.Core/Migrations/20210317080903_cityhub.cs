using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickPickWebApi.Core.Migrations
{
    public partial class cityhub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shops_distHubs_DistHubId",
                table: "Shops");

            migrationBuilder.DropTable(
                name: "distHubs");

            migrationBuilder.DropTable(
                name: "districts");

            migrationBuilder.DropIndex(
                name: "IX_Shops_DistHubId",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "DistHubId",
                table: "Shops");

            migrationBuilder.AddColumn<int>(
                name: "CityHubId",
                table: "Shops",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DistrictName = table.Column<string>(nullable: true),
                    StateName = table.Column<string>(nullable: true),
                    StateId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    CountryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cities_countrys_CountryId",
                        column: x => x.CountryId,
                        principalTable: "countrys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cities_states_StateId",
                        column: x => x.StateId,
                        principalTable: "states",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cityHubs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HubName = table.Column<string>(nullable: true),
                    CityName = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    StateName = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    CountryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cityHubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cityHubs_cities_CityId",
                        column: x => x.CityId,
                        principalTable: "cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cityHubs_countrys_CountryId",
                        column: x => x.CountryId,
                        principalTable: "countrys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cityHubs_states_StateId",
                        column: x => x.StateId,
                        principalTable: "states",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shops_CityHubId",
                table: "Shops",
                column: "CityHubId");

            migrationBuilder.CreateIndex(
                name: "IX_cities_CountryId",
                table: "cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_cities_StateId",
                table: "cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_cityHubs_CityId",
                table: "cityHubs",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_cityHubs_CountryId",
                table: "cityHubs",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_cityHubs_StateId",
                table: "cityHubs",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_cityHubs_CityHubId",
                table: "Shops",
                column: "CityHubId",
                principalTable: "cityHubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shops_cityHubs_CityHubId",
                table: "Shops");

            migrationBuilder.DropTable(
                name: "cityHubs");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropIndex(
                name: "IX_Shops_CityHubId",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "CityHubId",
                table: "Shops");

            migrationBuilder.AddColumn<int>(
                name: "DistHubId",
                table: "Shops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DistrictName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    StateName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "distHubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DistName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    HubName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_distHubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_distHubs_districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shops_DistHubId",
                table: "Shops",
                column: "DistHubId");

            migrationBuilder.CreateIndex(
                name: "IX_distHubs_DistrictId",
                table: "distHubs",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_districts_StateId",
                table: "districts",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_distHubs_DistHubId",
                table: "Shops",
                column: "DistHubId",
                principalTable: "distHubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickPickWebApi.Core.Migrations
{
    public partial class ff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customers");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Customers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}

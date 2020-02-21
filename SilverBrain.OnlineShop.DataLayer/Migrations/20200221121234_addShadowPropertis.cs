using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Silverbrain.OnlineShop.DataLayer.Migrations
{
    public partial class addShadowPropertis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByBrowserName",
                table: "Brands",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByIp",
                table: "Brands",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Brands",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Brands",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByBrowserName",
                table: "Brands",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByIp",
                table: "Brands",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "Brands",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "Brands",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByBrowserName",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "CreatedByIp",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "ModifiedByBrowserName",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "ModifiedByIp",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "Brands");
        }
    }
}

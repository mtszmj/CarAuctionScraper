using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarAuctionScrapper.Persistence.Migrations
{
    public partial class PricesProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Date",
                table: "Price",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "Price",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Price");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace CarAuctionScrapper.Persistence.Migrations
{
    public partial class DetailsProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Detail",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Detail",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Detail");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Detail");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace CarAuctionScrapper.Persistence.Migrations
{
    public partial class LocationProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Location_Latitude",
                table: "Offers",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Location_Longitude",
                table: "Offers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location_Latitude",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Location_Longitude",
                table: "Offers");
        }
    }
}

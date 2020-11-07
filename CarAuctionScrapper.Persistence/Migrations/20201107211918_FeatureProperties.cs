using Microsoft.EntityFrameworkCore.Migrations;

namespace CarAuctionScrapper.Persistence.Migrations
{
    public partial class FeatureProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Feature",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Feature");
        }
    }
}

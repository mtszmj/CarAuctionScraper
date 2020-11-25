using Microsoft.EntityFrameworkCore.Migrations;

namespace CarAuctionScraper.Persistence.Migrations
{
    public partial class AddOfferIsFinishedFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "Offers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "Offers");
        }
    }
}

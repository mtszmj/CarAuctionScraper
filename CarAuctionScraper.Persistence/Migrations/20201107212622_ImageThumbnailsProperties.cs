using Microsoft.EntityFrameworkCore.Migrations;

namespace CarAuctionScraper.Persistence.Migrations
{
    public partial class ImageThumbnailsProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Alt",
                table: "ThumbnailImageUrl",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Src",
                table: "ThumbnailImageUrl",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alt",
                table: "ThumbnailImageUrl");

            migrationBuilder.DropColumn(
                name: "Src",
                table: "ThumbnailImageUrl");
        }
    }
}

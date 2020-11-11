using Microsoft.EntityFrameworkCore.Migrations;

namespace CarAuctionScraper.Persistence.Migrations
{
    public partial class ImagesProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Alt",
                table: "FullImageUrl",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Src",
                table: "FullImageUrl",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alt",
                table: "FullImageUrl");

            migrationBuilder.DropColumn(
                name: "Src",
                table: "FullImageUrl");
        }
    }
}

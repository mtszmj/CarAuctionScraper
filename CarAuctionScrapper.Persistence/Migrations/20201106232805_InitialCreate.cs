using Microsoft.EntityFrameworkCore.Migrations;

namespace CarAuctionScrapper.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Url = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Url);
                });

            migrationBuilder.CreateTable(
                name: "Detail",
                columns: table => new
                {
                    OfferUrl = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detail", x => new { x.OfferUrl, x.Id });
                    table.ForeignKey(
                        name: "FK_Detail_Offers_OfferUrl",
                        column: x => x.OfferUrl,
                        principalTable: "Offers",
                        principalColumn: "Url",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feature",
                columns: table => new
                {
                    OfferUrl = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature", x => new { x.OfferUrl, x.Id });
                    table.ForeignKey(
                        name: "FK_Feature_Offers_OfferUrl",
                        column: x => x.OfferUrl,
                        principalTable: "Offers",
                        principalColumn: "Url",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FullImageUrl",
                columns: table => new
                {
                    OfferUrl = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullImageUrl", x => new { x.OfferUrl, x.Id });
                    table.ForeignKey(
                        name: "FK_FullImageUrl_Offers_OfferUrl",
                        column: x => x.OfferUrl,
                        principalTable: "Offers",
                        principalColumn: "Url",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    OfferUrl = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => new { x.OfferUrl, x.Id });
                    table.ForeignKey(
                        name: "FK_Price_Offers_OfferUrl",
                        column: x => x.OfferUrl,
                        principalTable: "Offers",
                        principalColumn: "Url",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThumbnailImageUrl",
                columns: table => new
                {
                    OfferUrl = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThumbnailImageUrl", x => new { x.OfferUrl, x.Id });
                    table.ForeignKey(
                        name: "FK_ThumbnailImageUrl_Offers_OfferUrl",
                        column: x => x.OfferUrl,
                        principalTable: "Offers",
                        principalColumn: "Url",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detail");

            migrationBuilder.DropTable(
                name: "Feature");

            migrationBuilder.DropTable(
                name: "FullImageUrl");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "ThumbnailImageUrl");

            migrationBuilder.DropTable(
                name: "Offers");
        }
    }
}

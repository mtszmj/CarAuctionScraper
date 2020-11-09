using Microsoft.EntityFrameworkCore.Migrations;

namespace CarAuctionScrapper.Persistence.Migrations
{
    public partial class ChangeOfferId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detail_Offers_OfferUrl",
                table: "Detail");

            migrationBuilder.DropForeignKey(
                name: "FK_Feature_Offers_OfferUrl",
                table: "Feature");

            migrationBuilder.DropForeignKey(
                name: "FK_FullImageUrl_Offers_OfferUrl",
                table: "FullImageUrl");

            migrationBuilder.DropForeignKey(
                name: "FK_Price_Offers_OfferUrl",
                table: "Price");

            migrationBuilder.DropForeignKey(
                name: "FK_ThumbnailImageUrl_Offers_OfferUrl",
                table: "ThumbnailImageUrl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ThumbnailImageUrl",
                table: "ThumbnailImageUrl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Price",
                table: "Price");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offers",
                table: "Offers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FullImageUrl",
                table: "FullImageUrl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feature",
                table: "Feature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Detail",
                table: "Detail");

            migrationBuilder.DropColumn(
                name: "OfferUrl",
                table: "ThumbnailImageUrl");

            migrationBuilder.DropColumn(
                name: "OfferUrl",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "OfferUrl",
                table: "FullImageUrl");

            migrationBuilder.DropColumn(
                name: "OfferUrl",
                table: "Feature");

            migrationBuilder.DropColumn(
                name: "OfferUrl",
                table: "Detail");

            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "ThumbnailImageUrl",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "Price",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Offers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Offers",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "FullImageUrl",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "Feature",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "Detail",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThumbnailImageUrl",
                table: "ThumbnailImageUrl",
                columns: new[] { "OfferId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Price",
                table: "Price",
                columns: new[] { "OfferId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offers",
                table: "Offers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FullImageUrl",
                table: "FullImageUrl",
                columns: new[] { "OfferId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feature",
                table: "Feature",
                columns: new[] { "OfferId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Detail",
                table: "Detail",
                columns: new[] { "OfferId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Detail_Offers_OfferId",
                table: "Detail",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feature_Offers_OfferId",
                table: "Feature",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FullImageUrl_Offers_OfferId",
                table: "FullImageUrl",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Price_Offers_OfferId",
                table: "Price",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThumbnailImageUrl_Offers_OfferId",
                table: "ThumbnailImageUrl",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detail_Offers_OfferId",
                table: "Detail");

            migrationBuilder.DropForeignKey(
                name: "FK_Feature_Offers_OfferId",
                table: "Feature");

            migrationBuilder.DropForeignKey(
                name: "FK_FullImageUrl_Offers_OfferId",
                table: "FullImageUrl");

            migrationBuilder.DropForeignKey(
                name: "FK_Price_Offers_OfferId",
                table: "Price");

            migrationBuilder.DropForeignKey(
                name: "FK_ThumbnailImageUrl_Offers_OfferId",
                table: "ThumbnailImageUrl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ThumbnailImageUrl",
                table: "ThumbnailImageUrl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Price",
                table: "Price");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offers",
                table: "Offers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FullImageUrl",
                table: "FullImageUrl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feature",
                table: "Feature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Detail",
                table: "Detail");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "ThumbnailImageUrl");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "FullImageUrl");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "Feature");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "Detail");

            migrationBuilder.AddColumn<string>(
                name: "OfferUrl",
                table: "ThumbnailImageUrl",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OfferUrl",
                table: "Price",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Offers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfferUrl",
                table: "FullImageUrl",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OfferUrl",
                table: "Feature",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OfferUrl",
                table: "Detail",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThumbnailImageUrl",
                table: "ThumbnailImageUrl",
                columns: new[] { "OfferUrl", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Price",
                table: "Price",
                columns: new[] { "OfferUrl", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offers",
                table: "Offers",
                column: "Url");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FullImageUrl",
                table: "FullImageUrl",
                columns: new[] { "OfferUrl", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feature",
                table: "Feature",
                columns: new[] { "OfferUrl", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Detail",
                table: "Detail",
                columns: new[] { "OfferUrl", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Detail_Offers_OfferUrl",
                table: "Detail",
                column: "OfferUrl",
                principalTable: "Offers",
                principalColumn: "Url",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feature_Offers_OfferUrl",
                table: "Feature",
                column: "OfferUrl",
                principalTable: "Offers",
                principalColumn: "Url",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FullImageUrl_Offers_OfferUrl",
                table: "FullImageUrl",
                column: "OfferUrl",
                principalTable: "Offers",
                principalColumn: "Url",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Price_Offers_OfferUrl",
                table: "Price",
                column: "OfferUrl",
                principalTable: "Offers",
                principalColumn: "Url",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThumbnailImageUrl_Offers_OfferUrl",
                table: "ThumbnailImageUrl",
                column: "OfferUrl",
                principalTable: "Offers",
                principalColumn: "Url",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

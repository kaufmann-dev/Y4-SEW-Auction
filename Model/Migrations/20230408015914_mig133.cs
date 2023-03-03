using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class mig133 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuctionItems_CUSTOMERS_CUSTOMER_ID",
                table: "AuctionItems");

            migrationBuilder.DropForeignKey(
                name: "FK_AuctionItems_WORKS_OF_ART_BT_ARTWORK_ID",
                table: "AuctionItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuctionItems",
                table: "AuctionItems");

            migrationBuilder.RenameTable(
                name: "AuctionItems",
                newName: "AUCTION_HAS_ITEMS_JT");

            migrationBuilder.RenameIndex(
                name: "IX_AuctionItems_CUSTOMER_ID",
                table: "AUCTION_HAS_ITEMS_JT",
                newName: "IX_AUCTION_HAS_ITEMS_JT_CUSTOMER_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AUCTION_HAS_ITEMS_JT",
                table: "AUCTION_HAS_ITEMS_JT",
                columns: new[] { "ARTWORK_ID", "CUSTOMER_ID" });

            migrationBuilder.AddForeignKey(
                name: "FK_AUCTION_HAS_ITEMS_JT_CUSTOMERS_CUSTOMER_ID",
                table: "AUCTION_HAS_ITEMS_JT",
                column: "CUSTOMER_ID",
                principalTable: "CUSTOMERS",
                principalColumn: "CUSTOMER_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AUCTION_HAS_ITEMS_JT_WORKS_OF_ART_BT_ARTWORK_ID",
                table: "AUCTION_HAS_ITEMS_JT",
                column: "ARTWORK_ID",
                principalTable: "WORKS_OF_ART_BT",
                principalColumn: "ARTWORK_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUCTION_HAS_ITEMS_JT_CUSTOMERS_CUSTOMER_ID",
                table: "AUCTION_HAS_ITEMS_JT");

            migrationBuilder.DropForeignKey(
                name: "FK_AUCTION_HAS_ITEMS_JT_WORKS_OF_ART_BT_ARTWORK_ID",
                table: "AUCTION_HAS_ITEMS_JT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AUCTION_HAS_ITEMS_JT",
                table: "AUCTION_HAS_ITEMS_JT");

            migrationBuilder.RenameTable(
                name: "AUCTION_HAS_ITEMS_JT",
                newName: "AuctionItems");

            migrationBuilder.RenameIndex(
                name: "IX_AUCTION_HAS_ITEMS_JT_CUSTOMER_ID",
                table: "AuctionItems",
                newName: "IX_AuctionItems_CUSTOMER_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuctionItems",
                table: "AuctionItems",
                columns: new[] { "ARTWORK_ID", "CUSTOMER_ID" });

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionItems_CUSTOMERS_CUSTOMER_ID",
                table: "AuctionItems",
                column: "CUSTOMER_ID",
                principalTable: "CUSTOMERS",
                principalColumn: "CUSTOMER_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionItems_WORKS_OF_ART_BT_ARTWORK_ID",
                table: "AuctionItems",
                column: "ARTWORK_ID",
                principalTable: "WORKS_OF_ART_BT",
                principalColumn: "ARTWORK_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

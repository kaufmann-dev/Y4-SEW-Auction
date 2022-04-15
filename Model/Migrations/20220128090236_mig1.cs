using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DESCRIPTION",
                table: "WORKS_OF_ART_BT",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "HEIGHT",
                table: "WORKS_OF_ART_BT",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "WEIGHT",
                table: "WORKS_OF_ART_BT",
                type: "float",
                precision: 6,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WIDTH",
                table: "WORKS_OF_ART_BT",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WORK_OF_ART_TYPE",
                table: "WORKS_OF_ART_BT",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AUCTIONS",
                columns: table => new
                {
                    AUCTION_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DATE_OF_AUCTION = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TOPIC = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUCTIONS", x => x.AUCTION_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CUSTOMERS",
                columns: table => new
                {
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LAST_NAME = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PHONE_NR = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CUSTOMER_NR = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERS", x => x.CUSTOMER_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AuctionItems",
                columns: table => new
                {
                    ARTWORK_ID = table.Column<int>(type: "int", nullable: false),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    PRICE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionItems", x => new { x.ARTWORK_ID, x.CUSTOMER_ID });
                    table.ForeignKey(
                        name: "FK_AuctionItems_CUSTOMERS_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "CUSTOMER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuctionItems_WORKS_OF_ART_BT_ARTWORK_ID",
                        column: x => x.ARTWORK_ID,
                        principalTable: "WORKS_OF_ART_BT",
                        principalColumn: "ARTWORK_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_WORKS_OF_ART_BT_NAME",
                table: "WORKS_OF_ART_BT",
                column: "NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuctionItems_CUSTOMER_ID",
                table: "AuctionItems",
                column: "CUSTOMER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuctionItems");

            migrationBuilder.DropTable(
                name: "AUCTIONS");

            migrationBuilder.DropTable(
                name: "CUSTOMERS");

            migrationBuilder.DropIndex(
                name: "IX_WORKS_OF_ART_BT_NAME",
                table: "WORKS_OF_ART_BT");

            migrationBuilder.DropColumn(
                name: "DESCRIPTION",
                table: "WORKS_OF_ART_BT");

            migrationBuilder.DropColumn(
                name: "HEIGHT",
                table: "WORKS_OF_ART_BT");

            migrationBuilder.DropColumn(
                name: "WEIGHT",
                table: "WORKS_OF_ART_BT");

            migrationBuilder.DropColumn(
                name: "WIDTH",
                table: "WORKS_OF_ART_BT");

            migrationBuilder.DropColumn(
                name: "WORK_OF_ART_TYPE",
                table: "WORKS_OF_ART_BT");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class mig29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
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
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERS", x => x.CUSTOMER_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WORKS_OF_ART_BT",
                columns: table => new
                {
                    ARTWORK_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AESTIMATED_VALUE = table.Column<int>(type: "int", nullable: false),
                    WORK_OF_ART_TYPE = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HEIGHT = table.Column<int>(type: "int", nullable: true),
                    WIDTH = table.Column<int>(type: "int", nullable: true),
                    WEIGHT = table.Column<float>(type: "float", precision: 6, scale: 2, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORKS_OF_ART_BT", x => x.ARTWORK_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AUCTION_HAS_ITEMS_JT",
                columns: table => new
                {
                    ARTWORK_ID = table.Column<int>(type: "int", nullable: false),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    AUCTION_ID = table.Column<int>(type: "int", nullable: false),
                    PRICE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUCTION_HAS_ITEMS_JT", x => new { x.ARTWORK_ID, x.CUSTOMER_ID, x.AUCTION_ID });
                    table.ForeignKey(
                        name: "FK_AUCTION_HAS_ITEMS_JT_AUCTIONS_AUCTION_ID",
                        column: x => x.AUCTION_ID,
                        principalTable: "AUCTIONS",
                        principalColumn: "AUCTION_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AUCTION_HAS_ITEMS_JT_CUSTOMERS_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "CUSTOMER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AUCTION_HAS_ITEMS_JT_WORKS_OF_ART_BT_ARTWORK_ID",
                        column: x => x.ARTWORK_ID,
                        principalTable: "WORKS_OF_ART_BT",
                        principalColumn: "ARTWORK_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AUCTION_HAS_ITEMS_JT_AUCTION_ID",
                table: "AUCTION_HAS_ITEMS_JT",
                column: "AUCTION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_AUCTION_HAS_ITEMS_JT_CUSTOMER_ID",
                table: "AUCTION_HAS_ITEMS_JT",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WORKS_OF_ART_BT_NAME",
                table: "WORKS_OF_ART_BT",
                column: "NAME",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AUCTION_HAS_ITEMS_JT");

            migrationBuilder.DropTable(
                name: "AUCTIONS");

            migrationBuilder.DropTable(
                name: "CUSTOMERS");

            migrationBuilder.DropTable(
                name: "WORKS_OF_ART_BT");
        }
    }
}

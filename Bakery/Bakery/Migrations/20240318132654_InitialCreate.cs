using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bakery.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BakingGoods",
                columns: table => new
                {
                    BakingGoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakingGoods", x => x.BakingGoodId);
                });

            migrationBuilder.CreateTable(
                name: "Batches",
                columns: table => new
                {
                    BatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    FinishTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    ScheduledFinishTime = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => x.BatchId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Supermarkets",
                columns: table => new
                {
                    SupermarketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supermarkets", x => x.SupermarketId);
                });

            migrationBuilder.CreateTable(
                name: "BakingGoodBatches",
                columns: table => new
                {
                    BakingGoodId = table.Column<int>(type: "int", nullable: false),
                    BatchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakingGoodBatches", x => new { x.BakingGoodId, x.BatchId });
                    table.ForeignKey(
                        name: "FK_BakingGoodBatches_BakingGoods_BakingGoodId",
                        column: x => x.BakingGoodId,
                        principalTable: "BakingGoods",
                        principalColumn: "BakingGoodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BakingGoodBatches_Batches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batches",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BatchIngredients",
                columns: table => new
                {
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchIngredients", x => new { x.BatchId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_BatchIngredients_Batches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batches",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatchIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderBakingGoods",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    BakingGoodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderBakingGoods", x => new { x.OrderId, x.BakingGoodId });
                    table.ForeignKey(
                        name: "FK_OrderBakingGoods_BakingGoods_BakingGoodId",
                        column: x => x.BakingGoodId,
                        principalTable: "BakingGoods",
                        principalColumn: "BakingGoodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderBakingGoods_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    TrackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    SupermarketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.TrackId);
                    table.ForeignKey(
                        name: "FK_Deliveries_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deliveries_Supermarkets_SupermarketId",
                        column: x => x.SupermarketId,
                        principalTable: "Supermarkets",
                        principalColumn: "SupermarketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BakingGoodBatches_BatchId",
                table: "BakingGoodBatches",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchIngredients_IngredientId",
                table: "BatchIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_OrderId",
                table: "Deliveries",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_SupermarketId",
                table: "Deliveries",
                column: "SupermarketId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderBakingGoods_BakingGoodId",
                table: "OrderBakingGoods",
                column: "BakingGoodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BakingGoodBatches");

            migrationBuilder.DropTable(
                name: "BatchIngredients");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "OrderBakingGoods");

            migrationBuilder.DropTable(
                name: "Batches");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Supermarkets");

            migrationBuilder.DropTable(
                name: "BakingGoods");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}

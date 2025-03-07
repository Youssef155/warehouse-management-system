using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStockTransfers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockTransferDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockTransferId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTransferDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockTransferDetails_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockTransferDetails_StockTransfers_StockTransferId",
                        column: x => x.StockTransferId,
                        principalTable: "StockTransfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 16, 52, 3, 963, DateTimeKind.Utc).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 16, 52, 3, 963, DateTimeKind.Utc).AddTicks(1589));

            migrationBuilder.UpdateData(
                table: "StockItems",
                keyColumns: new[] { "ItemId", "WarehouseId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 16, 52, 3, 963, DateTimeKind.Utc).AddTicks(5905));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 16, 52, 3, 963, DateTimeKind.Utc).AddTicks(2993));

            migrationBuilder.UpdateData(
                table: "SupplyOrderDetail",
                keyColumns: new[] { "ItemId", "SupplyOrderId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 16, 52, 3, 963, DateTimeKind.Utc).AddTicks(9361));

            migrationBuilder.UpdateData(
                table: "SupplyOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 16, 52, 3, 963, DateTimeKind.Utc).AddTicks(8162));

            migrationBuilder.UpdateData(
                table: "Warehouses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 16, 52, 3, 962, DateTimeKind.Utc).AddTicks(5939));

            migrationBuilder.UpdateData(
                table: "WithdrawalOrderDetail",
                keyColumns: new[] { "ItemId", "WithdrawalOrderId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 16, 52, 3, 964, DateTimeKind.Utc).AddTicks(2075));

            migrationBuilder.UpdateData(
                table: "WithdrawalOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 16, 52, 3, 964, DateTimeKind.Utc).AddTicks(967));

            migrationBuilder.CreateIndex(
                name: "IX_StockTransferDetails_ItemId",
                table: "StockTransferDetails",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransferDetails_StockTransferId",
                table: "StockTransferDetails",
                column: "StockTransferId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockTransferDetails");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 11, 7, 54, 646, DateTimeKind.Utc).AddTicks(4589));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 11, 7, 54, 646, DateTimeKind.Utc).AddTicks(1094));

            migrationBuilder.UpdateData(
                table: "StockItems",
                keyColumns: new[] { "ItemId", "WarehouseId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 11, 7, 54, 646, DateTimeKind.Utc).AddTicks(5654));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 11, 7, 54, 646, DateTimeKind.Utc).AddTicks(2647));

            migrationBuilder.UpdateData(
                table: "SupplyOrderDetail",
                keyColumns: new[] { "ItemId", "SupplyOrderId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 11, 7, 54, 647, DateTimeKind.Utc).AddTicks(1788));

            migrationBuilder.UpdateData(
                table: "SupplyOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 11, 7, 54, 646, DateTimeKind.Utc).AddTicks(7175));

            migrationBuilder.UpdateData(
                table: "Warehouses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 11, 7, 54, 645, DateTimeKind.Utc).AddTicks(5066));

            migrationBuilder.UpdateData(
                table: "WithdrawalOrderDetail",
                keyColumns: new[] { "ItemId", "WithdrawalOrderId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 11, 7, 54, 647, DateTimeKind.Utc).AddTicks(4869));

            migrationBuilder.UpdateData(
                table: "WithdrawalOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 11, 7, 54, 647, DateTimeKind.Utc).AddTicks(3625));
        }
    }
}

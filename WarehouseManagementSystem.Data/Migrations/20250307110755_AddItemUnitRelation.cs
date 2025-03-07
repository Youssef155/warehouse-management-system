using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddItemUnitRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemUnits",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    ConversionFactor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemUnits", x => new { x.ItemId, x.UnitId });
                    table.ForeignKey(
                        name: "FK_ItemUnits_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemUnits_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ItemUnits_UnitId",
                table: "ItemUnits",
                column: "UnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemUnits");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 6, 51, 33, 237, DateTimeKind.Utc).AddTicks(6634));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 6, 51, 33, 237, DateTimeKind.Utc).AddTicks(3335));

            migrationBuilder.UpdateData(
                table: "StockItems",
                keyColumns: new[] { "ItemId", "WarehouseId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 6, 51, 33, 237, DateTimeKind.Utc).AddTicks(7545));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 6, 51, 33, 237, DateTimeKind.Utc).AddTicks(4745));

            migrationBuilder.UpdateData(
                table: "SupplyOrderDetail",
                keyColumns: new[] { "ItemId", "SupplyOrderId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 6, 51, 33, 238, DateTimeKind.Utc).AddTicks(5819));

            migrationBuilder.UpdateData(
                table: "SupplyOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 6, 51, 33, 237, DateTimeKind.Utc).AddTicks(9464));

            migrationBuilder.UpdateData(
                table: "Warehouses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 6, 51, 33, 236, DateTimeKind.Utc).AddTicks(8381));

            migrationBuilder.UpdateData(
                table: "WithdrawalOrderDetail",
                keyColumns: new[] { "ItemId", "WithdrawalOrderId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 6, 51, 33, 239, DateTimeKind.Utc).AddTicks(71));

            migrationBuilder.UpdateData(
                table: "WithdrawalOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 6, 51, 33, 238, DateTimeKind.Utc).AddTicks(8638));
        }
    }
}

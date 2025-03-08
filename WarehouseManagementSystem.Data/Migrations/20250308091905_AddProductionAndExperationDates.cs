using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProductionAndExperationDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "StockItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ProductionDate",
                table: "StockItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 9, 19, 4, 282, DateTimeKind.Utc).AddTicks(830));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 9, 19, 4, 281, DateTimeKind.Utc).AddTicks(7168));

            migrationBuilder.UpdateData(
                table: "StockItems",
                keyColumns: new[] { "ItemId", "WarehouseId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedAt", "ExpirationDate", "ProductionDate" },
                values: new object[] { new DateTime(2025, 3, 8, 9, 19, 4, 282, DateTimeKind.Utc).AddTicks(1872), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 9, 19, 4, 281, DateTimeKind.Utc).AddTicks(8710));

            migrationBuilder.UpdateData(
                table: "SupplyOrderDetail",
                keyColumns: new[] { "ItemId", "SupplyOrderId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 9, 19, 4, 282, DateTimeKind.Utc).AddTicks(4876));

            migrationBuilder.UpdateData(
                table: "SupplyOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 9, 19, 4, 282, DateTimeKind.Utc).AddTicks(3276));

            migrationBuilder.UpdateData(
                table: "Warehouses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 9, 19, 4, 281, DateTimeKind.Utc).AddTicks(516));

            migrationBuilder.UpdateData(
                table: "WithdrawalOrderDetail",
                keyColumns: new[] { "ItemId", "WithdrawalOrderId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 9, 19, 4, 282, DateTimeKind.Utc).AddTicks(7883));

            migrationBuilder.UpdateData(
                table: "WithdrawalOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 9, 19, 4, 282, DateTimeKind.Utc).AddTicks(6666));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "ProductionDate",
                table: "StockItems");

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
        }
    }
}

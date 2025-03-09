using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditSupplyOrderDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShelfLifeDays",
                table: "SupplyOrderDetail");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "SupplyOrderDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 9, 12, 13, 14, 362, DateTimeKind.Utc).AddTicks(9788));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 9, 12, 13, 14, 362, DateTimeKind.Utc).AddTicks(6630));

            migrationBuilder.UpdateData(
                table: "StockItems",
                keyColumns: new[] { "ItemId", "WarehouseId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 9, 12, 13, 14, 363, DateTimeKind.Utc).AddTicks(706));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 9, 12, 13, 14, 362, DateTimeKind.Utc).AddTicks(7867));

            migrationBuilder.UpdateData(
                table: "SupplyOrderDetail",
                keyColumns: new[] { "ItemId", "SupplyOrderId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedAt", "ExpirationDate" },
                values: new object[] { new DateTime(2025, 3, 9, 12, 13, 14, 363, DateTimeKind.Utc).AddTicks(6345), new DateTime(2026, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "SupplyOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 9, 12, 13, 14, 363, DateTimeKind.Utc).AddTicks(2000));

            migrationBuilder.UpdateData(
                table: "Warehouses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 9, 12, 13, 14, 362, DateTimeKind.Utc).AddTicks(1031));

            migrationBuilder.UpdateData(
                table: "WithdrawalOrderDetail",
                keyColumns: new[] { "ItemId", "WithdrawalOrderId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 9, 12, 13, 14, 363, DateTimeKind.Utc).AddTicks(9296));

            migrationBuilder.UpdateData(
                table: "WithdrawalOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 9, 12, 13, 14, 363, DateTimeKind.Utc).AddTicks(8153));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "SupplyOrderDetail");

            migrationBuilder.AddColumn<int>(
                name: "ShelfLifeDays",
                table: "SupplyOrderDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 9, 19, 4, 282, DateTimeKind.Utc).AddTicks(1872));

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
                columns: new[] { "CreatedAt", "ShelfLifeDays" },
                values: new object[] { new DateTime(2025, 3, 8, 9, 19, 4, 282, DateTimeKind.Utc).AddTicks(4876), 365 });

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
    }
}

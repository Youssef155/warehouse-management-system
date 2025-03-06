using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasurementUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockItems",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItems", x => new { x.WarehouseId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_StockItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockItems_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockTransfers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromWarehouseId = table.Column<int>(type: "int", nullable: false),
                    ToWarehouseId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TransferDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTransfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockTransfers_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockTransfers_Warehouses_FromWarehouseId",
                        column: x => x.FromWarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockTransfers_Warehouses_ToWarehouseId",
                        column: x => x.ToWarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplyOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplyOrders_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplyOrders_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WithdrawalOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WithdrawalOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WithdrawalOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WithdrawalOrders_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplyOrderDetail",
                columns: table => new
                {
                    SupplyOrderId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShelfLifeDays = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyOrderDetail", x => new { x.SupplyOrderId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_SupplyOrderDetail_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplyOrderDetail_SupplyOrders_SupplyOrderId",
                        column: x => x.SupplyOrderId,
                        principalTable: "SupplyOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WithdrawalOrderDetail",
                columns: table => new
                {
                    WithdrawalOrderId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WithdrawalOrderDetail", x => new { x.WithdrawalOrderId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_WithdrawalOrderDetail_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WithdrawalOrderDetail_WithdrawalOrders_WithdrawalOrderId",
                        column: x => x.WithdrawalOrderId,
                        principalTable: "WithdrawalOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Phone", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 3, 6, 5, 47, 40, 20, DateTimeKind.Utc).AddTicks(1634), "john@electronics.com", "John Electronics", "987-654", null });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Code", "CreatedAt", "MeasurementUnit", "Name", "UpdatedAt" },
                values: new object[] { 1, "ITM001", new DateTime(2025, 3, 6, 5, 47, 40, 19, DateTimeKind.Utc).AddTicks(7785), "Piece", "Laptop", null });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "CreatedAt", "Email", "Fax", "Mobile", "Name", "Phone", "UpdatedAt", "Website" },
                values: new object[] { 1, new DateTime(2025, 3, 6, 5, 47, 40, 19, DateTimeKind.Utc).AddTicks(9589), "contact@techsupplier.com", "123-457", "123456789", "TechSupplier Inc.", "123-456", null, "www.techsupplier.com" });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "Id", "Address", "CreatedAt", "Manager", "Name", "UpdatedAt" },
                values: new object[] { 1, "123 Street, City", new DateTime(2025, 3, 6, 5, 47, 40, 19, DateTimeKind.Utc).AddTicks(2439), "John Doe", "Main Warehouse", null });

            migrationBuilder.InsertData(
                table: "StockItems",
                columns: new[] { "ItemId", "WarehouseId", "CreatedAt", "Id", "Quantity", "UpdatedAt" },
                values: new object[] { 1, 1, new DateTime(2025, 3, 6, 5, 47, 40, 20, DateTimeKind.Utc).AddTicks(2648), 0, 50, null });

            migrationBuilder.InsertData(
                table: "SupplyOrders",
                columns: new[] { "Id", "CreatedAt", "OrderDate", "OrderNumber", "SupplierId", "UpdatedAt", "WarehouseId" },
                values: new object[] { 1, new DateTime(2025, 3, 6, 5, 47, 40, 20, DateTimeKind.Utc).AddTicks(4011), new DateTime(2025, 3, 6, 5, 47, 40, 20, DateTimeKind.Utc).AddTicks(4617), "SO001", 1, null, 1 });

            migrationBuilder.InsertData(
                table: "WithdrawalOrders",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "OrderDate", "OrderNumber", "UpdatedAt", "WarehouseId" },
                values: new object[] { 1, new DateTime(2025, 3, 6, 5, 47, 40, 20, DateTimeKind.Utc).AddTicks(7059), 1, new DateTime(2025, 3, 6, 5, 47, 40, 20, DateTimeKind.Utc).AddTicks(7656), "WO001", null, 1 });

            migrationBuilder.InsertData(
                table: "SupplyOrderDetail",
                columns: new[] { "ItemId", "SupplyOrderId", "CreatedAt", "Id", "ProductionDate", "Quantity", "ShelfLifeDays", "UpdatedAt" },
                values: new object[] { 1, 1, new DateTime(2025, 3, 6, 5, 47, 40, 20, DateTimeKind.Utc).AddTicks(5194), 0, new DateTime(2025, 2, 6, 5, 47, 40, 20, DateTimeKind.Utc).AddTicks(5769), 10, 365, null });

            migrationBuilder.InsertData(
                table: "WithdrawalOrderDetail",
                columns: new[] { "ItemId", "WithdrawalOrderId", "CreatedAt", "Id", "Quantity", "UpdatedAt" },
                values: new object[] { 1, 1, new DateTime(2025, 3, 6, 5, 47, 40, 20, DateTimeKind.Utc).AddTicks(8255), 0, 5, null });

            migrationBuilder.CreateIndex(
                name: "IX_StockItems_ItemId",
                table: "StockItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransfers_FromWarehouseId",
                table: "StockTransfers",
                column: "FromWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransfers_ItemId",
                table: "StockTransfers",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransfers_ToWarehouseId",
                table: "StockTransfers",
                column: "ToWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyOrderDetail_ItemId",
                table: "SupplyOrderDetail",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyOrders_SupplierId",
                table: "SupplyOrders",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyOrders_WarehouseId",
                table: "SupplyOrders",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_WithdrawalOrderDetail_ItemId",
                table: "WithdrawalOrderDetail",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_WithdrawalOrders_CustomerId",
                table: "WithdrawalOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_WithdrawalOrders_WarehouseId",
                table: "WithdrawalOrders",
                column: "WarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockItems");

            migrationBuilder.DropTable(
                name: "StockTransfers");

            migrationBuilder.DropTable(
                name: "SupplyOrderDetail");

            migrationBuilder.DropTable(
                name: "WithdrawalOrderDetail");

            migrationBuilder.DropTable(
                name: "SupplyOrders");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "WithdrawalOrders");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}

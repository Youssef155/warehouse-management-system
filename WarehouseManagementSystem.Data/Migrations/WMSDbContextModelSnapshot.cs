﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WarehouseManagementSystem.Data;

#nullable disable

namespace WarehouseManagementSystem.Data.Migrations
{
    [DbContext(typeof(WMSDbContext))]
    partial class WMSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 3, 9, 12, 13, 14, 362, DateTimeKind.Utc).AddTicks(9788),
                            Email = "john@electronics.com",
                            Name = "John Electronics",
                            Phone = "987-654"
                        });
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("MeasurementUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "ITM001",
                            CreatedAt = new DateTime(2025, 3, 9, 12, 13, 14, 362, DateTimeKind.Utc).AddTicks(6630),
                            MeasurementUnit = "Piece",
                            Name = "Laptop"
                        });
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.ItemUnit", b =>
                {
                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<decimal>("ConversionFactor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ItemId", "UnitId");

                    b.HasIndex("UnitId");

                    b.ToTable("ItemUnits");
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.StockItem", b =>
                {
                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("WarehouseId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("StockItems");

                    b.HasData(
                        new
                        {
                            WarehouseId = 1,
                            ItemId = 1,
                            CreatedAt = new DateTime(2025, 3, 9, 12, 13, 14, 363, DateTimeKind.Utc).AddTicks(706),
                            ExpirationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Id = 0,
                            ProductionDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 50
                        });
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.StockTransfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("FromWarehouseId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("ToWarehouseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransferDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FromWarehouseId");

                    b.HasIndex("ItemId");

                    b.HasIndex("ToWarehouseId");

                    b.ToTable("StockTransfers");
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.StockTransferDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("StockTransferId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("StockTransferId");

                    b.ToTable("StockTransferDetails");
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 3, 9, 12, 13, 14, 362, DateTimeKind.Utc).AddTicks(7867),
                            Email = "contact@techsupplier.com",
                            Fax = "123-457",
                            Mobile = "123456789",
                            Name = "TechSupplier Inc.",
                            Phone = "123-456",
                            Website = "www.techsupplier.com"
                        });
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.SupplyOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("SupplyOrders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 3, 9, 12, 13, 14, 363, DateTimeKind.Utc).AddTicks(2000),
                            OrderDate = new DateTime(2024, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderNumber = "SO001",
                            SupplierId = 1,
                            WarehouseId = 1
                        });
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.SupplyOrderDetail", b =>
                {
                    b.Property<int>("SupplyOrderId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("SupplyOrderId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("SupplyOrderDetail");

                    b.HasData(
                        new
                        {
                            SupplyOrderId = 1,
                            ItemId = 1,
                            CreatedAt = new DateTime(2025, 3, 9, 12, 13, 14, 363, DateTimeKind.Utc).AddTicks(6345),
                            ExpirationDate = new DateTime(2026, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Id = 0,
                            ProductionDate = new DateTime(2024, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 10
                        });
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Manager")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Warehouses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Street, City",
                            CreatedAt = new DateTime(2025, 3, 9, 12, 13, 14, 362, DateTimeKind.Utc).AddTicks(1031),
                            Manager = "John Doe",
                            Name = "Main Warehouse"
                        });
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.WithdrawalOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("WithdrawalOrders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 3, 9, 12, 13, 14, 363, DateTimeKind.Utc).AddTicks(8153),
                            CustomerId = 1,
                            OrderDate = new DateTime(2024, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderNumber = "WO001",
                            WarehouseId = 1
                        });
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.WithdrawalOrderDetail", b =>
                {
                    b.Property<int>("WithdrawalOrderId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("WithdrawalOrderId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("WithdrawalOrderDetail");

                    b.HasData(
                        new
                        {
                            WithdrawalOrderId = 1,
                            ItemId = 1,
                            CreatedAt = new DateTime(2025, 3, 9, 12, 13, 14, 363, DateTimeKind.Utc).AddTicks(9296),
                            Id = 0,
                            Quantity = 5
                        });
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.ItemUnit", b =>
                {
                    b.HasOne("WarehouseManagementSystem.Data.Models.Item", "Item")
                        .WithMany("ItemUnits")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarehouseManagementSystem.Data.Models.Unit", "Unit")
                        .WithMany("ItemUnits")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.StockItem", b =>
                {
                    b.HasOne("WarehouseManagementSystem.Data.Models.Item", "Item")
                        .WithMany("StockItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarehouseManagementSystem.Data.Models.Warehouse", "Warehouse")
                        .WithMany("StockItems")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.StockTransfer", b =>
                {
                    b.HasOne("WarehouseManagementSystem.Data.Models.Warehouse", "FromWarehouse")
                        .WithMany()
                        .HasForeignKey("FromWarehouseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WarehouseManagementSystem.Data.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarehouseManagementSystem.Data.Models.Warehouse", "ToWarehouse")
                        .WithMany()
                        .HasForeignKey("ToWarehouseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FromWarehouse");

                    b.Navigation("Item");

                    b.Navigation("ToWarehouse");
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.StockTransferDetail", b =>
                {
                    b.HasOne("WarehouseManagementSystem.Data.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WarehouseManagementSystem.Data.Models.StockTransfer", "StockTransfer")
                        .WithMany("StockTransferDetails")
                        .HasForeignKey("StockTransferId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("StockTransfer");
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.SupplyOrder", b =>
                {
                    b.HasOne("WarehouseManagementSystem.Data.Models.Supplier", "Supplier")
                        .WithMany("SupplyOrders")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarehouseManagementSystem.Data.Models.Warehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.SupplyOrderDetail", b =>
                {
                    b.HasOne("WarehouseManagementSystem.Data.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarehouseManagementSystem.Data.Models.SupplyOrder", "SupplyOrder")
                        .WithMany("SupplyOrderDetails")
                        .HasForeignKey("SupplyOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("SupplyOrder");
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.WithdrawalOrder", b =>
                {
                    b.HasOne("WarehouseManagementSystem.Data.Models.Customer", "Customer")
                        .WithMany("WithdrawalOrders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarehouseManagementSystem.Data.Models.Warehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.WithdrawalOrderDetail", b =>
                {
                    b.HasOne("WarehouseManagementSystem.Data.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarehouseManagementSystem.Data.Models.WithdrawalOrder", "WithdrawalOrder")
                        .WithMany("WithdrawalOrderDetails")
                        .HasForeignKey("WithdrawalOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("WithdrawalOrder");
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.Customer", b =>
                {
                    b.Navigation("WithdrawalOrders");
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.Item", b =>
                {
                    b.Navigation("ItemUnits");

                    b.Navigation("StockItems");
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.StockTransfer", b =>
                {
                    b.Navigation("StockTransferDetails");
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.Supplier", b =>
                {
                    b.Navigation("SupplyOrders");
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.SupplyOrder", b =>
                {
                    b.Navigation("SupplyOrderDetails");
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.Unit", b =>
                {
                    b.Navigation("ItemUnits");
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.Warehouse", b =>
                {
                    b.Navigation("StockItems");
                });

            modelBuilder.Entity("WarehouseManagementSystem.Data.Models.WithdrawalOrder", b =>
                {
                    b.Navigation("WithdrawalOrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using WarehouseManagementSystem.Data.Models;


namespace WarehouseManagementSystem.Data.SeedingData;


public static class ModelBuilderExtensions
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Warehouse>().HasData(
            new Warehouse { Id = 1, Name = "Main Warehouse", Address = "123 Street, City", Manager = "John Doe" }
        );

        modelBuilder.Entity<Item>().HasData(
            new Item { Id = 1, Code = "ITM001", Name = "Laptop", MeasurementUnit = "Piece" }
        );

        modelBuilder.Entity<Supplier>().HasData(
            new Supplier { Id = 1, Name = "TechSupplier Inc.", Phone = "123-456", Fax = "123-457", Mobile = "123456789", Email = "contact@techsupplier.com", Website = "www.techsupplier.com" }
        );

        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, Name = "John Electronics", Phone = "987-654", Email = "john@electronics.com" }
        );

        modelBuilder.Entity<StockItem>().HasData(
            new StockItem { WarehouseId = 1, ItemId = 1, Quantity = 50 }
        );

        modelBuilder.Entity<SupplyOrder>().HasData(
            new SupplyOrder { Id = 1, WarehouseId = 1, SupplierId = 1, OrderNumber = "SO001", OrderDate = new DateTime(2024, 3, 6) }
        );

        modelBuilder.Entity<SupplyOrderDetail>().HasData(
            new SupplyOrderDetail { SupplyOrderId = 1, ItemId = 1, Quantity = 10, ProductionDate = new DateTime(2024, 2, 6), ShelfLifeDays = 365 }
        );

        modelBuilder.Entity<WithdrawalOrder>().HasData(
            new WithdrawalOrder { Id = 1, WarehouseId = 1, CustomerId = 1, OrderNumber = "WO001", OrderDate = new DateTime(2024, 3, 6) }
        );

        modelBuilder.Entity<WithdrawalOrderDetail>().HasData(
            new WithdrawalOrderDetail { WithdrawalOrderId = 1, ItemId = 1, Quantity = 5 }
        );
    }
}


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Configuration;
using WarehouseManagementSystem.Data.Models;
using WarehouseManagementSystem.Data.SeedingData;

namespace WarehouseManagementSystem.Data;


public class WMSDbContext : DbContext
{
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<StockItem> StockItems { get; set; }
    public DbSet<SupplyOrder> SupplyOrders { get; set; }
    public DbSet<WithdrawalOrder> WithdrawalOrders { get; set; }
    public DbSet<StockTransfer> StockTransfers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }
        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Composite Primary Keys
        modelBuilder.Entity<StockItem>().HasKey(si => new { si.WarehouseId, si.ItemId });
        modelBuilder.Entity<SupplyOrderDetail>().HasKey(sod => new { sod.SupplyOrderId, sod.ItemId });
        modelBuilder.Entity<WithdrawalOrderDetail>().HasKey(wod => new { wod.WithdrawalOrderId, wod.ItemId });

        // 🔹 Fix Foreign Key Issue for `StockTransfers`
        modelBuilder.Entity<StockTransfer>()
            .HasOne(st => st.FromWarehouse)
            .WithMany()
            .HasForeignKey(st => st.FromWarehouseId)
            .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete

        modelBuilder.Entity<StockTransfer>()
            .HasOne(st => st.ToWarehouse)
            .WithMany()
            .HasForeignKey(st => st.ToWarehouseId)
            .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete

        // Data Seeding
        modelBuilder.SeedData();
    }
}


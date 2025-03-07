using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Configuration;
using WarehouseManagementSystem.Data.Models;
using WarehouseManagementSystem.Data.SeedingData;

namespace WarehouseManagementSystem.Data;


public class WMSDbContext : DbContext
{

    public WMSDbContext() { }
    public WMSDbContext(DbContextOptions<WMSDbContext> options) : base(options)
    {
    }

    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<ItemUnit> ItemUnits { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<StockItem> StockItems { get; set; }
    public DbSet<SupplyOrder> SupplyOrders { get; set; }
    public DbSet<WithdrawalOrder> WithdrawalOrders { get; set; }
    public DbSet<StockTransfer> StockTransfers { get; set; }
    public DbSet<StockTransferDetail> StockTransferDetails { get; set; }

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

        // Define Many-to-Many Relationship
        modelBuilder.Entity<ItemUnit>()
            .HasKey(iu => new { iu.ItemId, iu.UnitId });

        modelBuilder.Entity<ItemUnit>()
            .HasOne(iu => iu.Item)
            .WithMany(i => i.ItemUnits)
            .HasForeignKey(iu => iu.ItemId);

        modelBuilder.Entity<ItemUnit>()
            .HasOne(iu => iu.Unit)
            .WithMany(u => u.ItemUnits)
            .HasForeignKey(iu => iu.UnitId);

        // Fix Foreign Key Issue for `StockTransfers`
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

        modelBuilder.Entity<StockTransferDetail>()
            .HasOne(d => d.StockTransfer)
            .WithMany(t => t.StockTransferDetails)
            .HasForeignKey(d => d.StockTransferId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<StockTransferDetail>()
            .HasOne(d => d.Item)
            .WithMany()
            .HasForeignKey(d => d.ItemId)
            .OnDelete(DeleteBehavior.Restrict);

        // Data Seeding
        modelBuilder.SeedData();
    }
}


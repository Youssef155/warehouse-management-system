using WarehouseManagementSystem.Data.Models;
using WarehouseManagementSystem.Data.Repositories.Interfaces;
using WarehouseManagementSystem.Data.Repositories;
using WarehouseManagementSystem.Data.UOW.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace WarehouseManagementSystem.Data.UOW;

public class UnitOfWork : IUnitOfWork
{
    protected readonly WMSDbContext _context;
    public IWarehouseRepository Warehouses { get; }
    public IRepository<Item> Items { get; }
    public IStockItemRepository StockItems { get; }
    public ISupplierRepository Suppliers { get; }
    public IRepository<Customer> Customers { get; }
    public ISupplyOrderRepository SupplyOrders {  get; }
    public IWithdrawalOrderRepository WithdrawalOrders { get; }
    public IRepository<StockTransfer> StockTransfers { get; }
    public IStockItemRepository StockItemRepository { get; }

    public UnitOfWork(WMSDbContext context)
    {
        _context = context;
        Warehouses = new WarehouseRepository(_context);
        Items = new Repository<Item>(_context);
        Suppliers = new SupplierRepository(_context);
        Customers = new Repository<Customer>(_context);
        SupplyOrders = new SupplyOrderRepository(_context);
        WithdrawalOrders = new WithdrawalOrderRepository(_context);
        StockTransfers = new Repository<StockTransfer>(_context);
        StockItemRepository = new StockItemRepository(_context);
        StockItems = new StockItemRepository(context);
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _context.Database.BeginTransactionAsync();
    }


    public async Task SaveAsync() => await _context.SaveChangesAsync();

    public async void Dispose() => await _context.DisposeAsync();
}

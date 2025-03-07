using WarehouseManagementSystem.Data.Models;
using WarehouseManagementSystem.Data.Repositories.Interfaces;
using WarehouseManagementSystem.Data.Repositories;
using WarehouseManagementSystem.Data.UOW.Interfaces;

namespace WarehouseManagementSystem.Data.UOW;

public class UnitOfWork : IUnitOfWork
{
    private readonly WMSDbContext _context;
    public IRepository<Warehouse> Warehouses { get; }
    public IRepository<Item> Items { get; }
    public IRepository<Supplier> Suppliers { get; }
    public IRepository<Customer> Customers { get; }
    public IRepository<SupplyOrder> SupplyOrders {  get; }
    public IRepository<WithdrawalOrder> WithdrawalOrders { get; }
    public IRepository<StockTransfer> StockTransfers { get; }
    public UnitOfWork(WMSDbContext context)
    {
        _context = context;
        Warehouses = new Repository<Warehouse>(_context);
        Items = new Repository<Item>(_context);
        Suppliers = new Repository<Supplier>(_context);
        Customers = new Repository<Customer>(_context);
        SupplyOrders = new Repository<SupplyOrder>(_context);
        WithdrawalOrders = new Repository<WithdrawalOrder>(_context);
        StockTransfers = new Repository<StockTransfer>(_context);
    }

    public async Task SaveAsync() => await _context.SaveChangesAsync();

    public async void Dispose() => await _context.DisposeAsync();
}

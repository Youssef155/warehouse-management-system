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

    public UnitOfWork(WMSDbContext context)
    {
        _context = context;
        Warehouses = new Repository<Warehouse>(_context);
        Items = new Repository<Item>(_context);
        Suppliers = new Repository<Supplier>(_context);
        Customers = new Repository<Customer>(_context);
        SupplyOrders = new Repository<SupplyOrder>(_context);
    }

    public void Save() => _context.SaveChanges();

    public void Dispose() => _context.Dispose();
}

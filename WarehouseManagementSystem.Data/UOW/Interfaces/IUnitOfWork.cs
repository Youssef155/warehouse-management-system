using Microsoft.EntityFrameworkCore.Storage;
using WarehouseManagementSystem.Data.Models;
using WarehouseManagementSystem.Data.Repositories.Interfaces;

namespace WarehouseManagementSystem.Data.UOW.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IWarehouseRepository Warehouses { get; }
    public IRepository<Item> Items { get; }
    public IStockItemRepository StockItems { get; }
    public ISupplierRepository Suppliers { get; }
    public IRepository<Customer> Customers { get; }
    public ISupplyOrderRepository SupplyOrders { get; }
    public IRepository<WithdrawalOrder> WithdrawalOrders { get; }
    public IRepository<StockTransfer> StockTransfers { get; }
    public IStockItemRepository StockItemRepository { get; }
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task SaveAsync();
}

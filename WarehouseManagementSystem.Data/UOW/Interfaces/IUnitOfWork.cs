using WarehouseManagementSystem.Data.Models;
using WarehouseManagementSystem.Data.Repositories.Interfaces;

namespace WarehouseManagementSystem.Data.UOW.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Warehouse> Warehouses { get; }
    IRepository<Item> Items { get; }
    IRepository<Supplier> Suppliers { get; }
    IRepository<Customer> Customers { get; }
    IRepository<SupplyOrder> SupplyOrders { get; }
    IRepository<WithdrawalOrder> WithdrawalOrders { get; }
    IRepository<StockTransfer> StockTransfers { get; }
    void Save();
}

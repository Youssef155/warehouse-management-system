using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Data.Models;

namespace WarehouseManagementSystem.Data.Repositories.Interfaces;

public interface IStockItemRepository : IRepository<StockItem>
{
    Task<List<StockItem>> GetStockWithItemAndWarehouseAsync();
    Task<List<StockItem>> GetItemsByWarehousesAsync(List<int> warehouseIds);
    IQueryable<StockItem> GetQueryable();
}

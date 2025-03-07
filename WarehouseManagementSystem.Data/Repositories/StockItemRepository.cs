using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Data.Models;
using WarehouseManagementSystem.Data.Repositories.Interfaces;

namespace WarehouseManagementSystem.Data.Repositories;

public class StockItemRepository : Repository<StockItem>, IStockItemRepository
{
    private readonly WMSDbContext _context;

    public StockItemRepository(WMSDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<StockItem>> GetStockWithItemAndWarehouseAsync()
    {
        return await _context.StockItems
            .Include(s => s.Item) // Load related Item
            .Include(s => s.Warehouse) // Load related Warehouse
            .ToListAsync();
    }
}

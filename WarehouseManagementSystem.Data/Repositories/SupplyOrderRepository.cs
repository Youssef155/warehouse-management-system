using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Data.Models;
using WarehouseManagementSystem.Data.Repositories.Interfaces;

namespace WarehouseManagementSystem.Data.Repositories
{
    public class SupplyOrderRepository : Repository<SupplyOrder>, ISupplyOrderRepository
    {
        private readonly WMSDbContext _dbContext;
        public SupplyOrderRepository(WMSDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<SupplyOrder>> GetOrdersBySupplierIdAsync(int supplierId)
        {
            return await _dbContext.SupplyOrders
                .Where(o => o.SupplierId == supplierId)
                .ToListAsync();
        }
    }
}

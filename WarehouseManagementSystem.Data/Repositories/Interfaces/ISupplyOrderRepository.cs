using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Data.Models;

namespace WarehouseManagementSystem.Data.Repositories.Interfaces
{
    public interface ISupplyOrderRepository : IRepository<SupplyOrder>
    {
        Task<List<SupplyOrder>> GetOrdersBySupplierIdAsync(int supplierId);
    }
}

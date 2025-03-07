using System;
using System.Collections.Generic;
using WarehouseManagementSystem.Data.Models;

namespace WarehouseManagementSystem.Business.Interfaces;


public interface ISupplyOrderService
{
    Task<IEnumerable<SupplyOrder>> GetAllSupplyOrdersAsync();
    Task<SupplyOrder> GetSupplyOrderByIdAsync(int id);
    Task CreateSupplyOrderAsync(int warehouseId, int supplierId, string orderNumber, DateTime orderDate, List<SupplyOrderDetail> details);
}

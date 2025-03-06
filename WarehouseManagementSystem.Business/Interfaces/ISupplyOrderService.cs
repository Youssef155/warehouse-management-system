using System;
using System.Collections.Generic;
using WarehouseManagementSystem.Data.Models;

namespace WarehouseManagementSystem.Business.Interfaces;


public interface ISupplyOrderService
{
    IEnumerable<SupplyOrder> GetAllSupplyOrders();
    SupplyOrder GetSupplyOrderById(int id);
    void CreateSupplyOrder(int warehouseId, int supplierId, string orderNumber, DateTime orderDate, List<SupplyOrderDetail> details);
}

using System;
using System.Collections.Generic;
using WarehouseManagementSystem.Data.Models;

namespace WarehouseManagementSystem.Business.Interfaces;


public interface IWithdrawalOrderService
{
    IEnumerable<WithdrawalOrder> GetAllWithdrawalOrders();
    WithdrawalOrder GetWithdrawalOrderById(int id);
    void CreateWithdrawalOrder(int warehouseId, int customerId, string orderNumber, DateTime orderDate, List<WithdrawalOrderDetail> details);
}

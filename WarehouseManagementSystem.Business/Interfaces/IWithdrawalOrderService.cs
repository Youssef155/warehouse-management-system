using System;
using System.Collections.Generic;
using WarehouseManagementSystem.Data.Models;

namespace WarehouseManagementSystem.Business.Interfaces;


public interface IWithdrawalOrderService
{
    Task<IEnumerable<WithdrawalOrder>> GetAllWithdrawalOrdersAsync();
    Task<WithdrawalOrder> GetWithdrawalOrderByIdAsync(int id);
    Task CreateWithdrawalOrderAsync(int warehouseId, int customerId, string orderNumber, DateTime orderDate, List<WithdrawalOrderDetail> details);
}

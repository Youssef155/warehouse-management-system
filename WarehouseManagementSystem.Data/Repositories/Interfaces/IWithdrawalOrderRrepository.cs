using System;
using System.Collections.Generic;
using WarehouseManagementSystem.Data.Models;

namespace WarehouseManagementSystem.Data.Repositories.Interfaces;


public interface IWithdrawalOrderRepository : IRepository<WithdrawalOrder>
{
    IEnumerable<WithdrawalOrder> GetByDateRange(DateTime startDate, DateTime endDate);
    IEnumerable<WithdrawalOrder> GetByWarehouse(int warehouseId);
}

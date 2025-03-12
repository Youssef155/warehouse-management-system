using System;
using System.Collections.Generic;
using WarehouseManagementSystem.Data.Models;

namespace WarehouseManagementSystem.Data.Repositories.Interfaces;


public interface IWithdrawalOrderRepository : IRepository<WithdrawalOrder>
{
    Task<IEnumerable<WithdrawalOrder>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    Task<IEnumerable<WithdrawalOrder>> GetByWarehouseAsync(int warehouseId);
}

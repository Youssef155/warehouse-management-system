using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Data.Models;
using WarehouseManagementSystem.Data.Repositories.Interfaces;

namespace WarehouseManagementSystem.Data.Repositories;

public class WithdrawalOrderRepository : Repository<WithdrawalOrder>, IWithdrawalOrderRepository
{
    private readonly WMSDbContext _context;
    public WithdrawalOrderRepository(WMSDbContext context) : base(context)
    {
        _context = context;
    }
    public IEnumerable<WithdrawalOrder> GetByDateRange(DateTime startDate, DateTime endDate)
    {
        return _context.WithdrawalOrders
                       .Where(order => order.OrderDate >= startDate && order.OrderDate <= endDate)
                       .ToList();
    }

    public IEnumerable<WithdrawalOrder> GetByWarehouse(int warehouseId)
    {
        return _context.WithdrawalOrders
                       .Where(order => order.WarehouseId == warehouseId)
                       .ToList();
    }
}

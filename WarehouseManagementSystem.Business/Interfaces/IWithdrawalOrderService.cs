using System;
using System.Collections.Generic;
using WarehouseManagementSystem.Core.DTOs;
using WarehouseManagementSystem.Data.Models;

namespace WarehouseManagementSystem.Business.Interfaces;


public interface IWithdrawalOrderService
{
    Task<IEnumerable<WithdrawalOrderDTO>> GetAllWithdrawalOrdersAsync();
    Task<WithdrawalOrderDTO> GetWithdrawalOrderByIdAsync(int id);
    Task CreateOrderAsync(WithdrawalOrderDTO orderDto);
    Task UpdateOrderAsync(WithdrawalOrderDTO orderDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<WithdrawalOrderDTO>> GetOrdersByDateRange(DateTime startDate, DateTime endDate);
    Task<IEnumerable<WithdrawalOrderDTO>> GetOrdersByWarehouse(int warehouseId);
}

using System;
using System.Collections.Generic;
using WarehouseManagementSystem.Business.Interfaces;
using WarehouseManagementSystem.Data.Models;
using WarehouseManagementSystem.Data.UOW.Interfaces;

namespace WarehouseManagementSystem.Business.Services;



public class WithdrawalOrderService : IWithdrawalOrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public WithdrawalOrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<WithdrawalOrder>> GetAllWithdrawalOrdersAsync() => 
        await _unitOfWork.WithdrawalOrders.GetAllAsync();

    public async Task<WithdrawalOrder> GetWithdrawalOrderByIdAsync(int id) =>
        await _unitOfWork.WithdrawalOrders.GetByIdAsync(id);

    public async Task CreateWithdrawalOrderAsync(int warehouseId, int customerId, string orderNumber, DateTime orderDate, List<WithdrawalOrderDetail> details)
    {
        if (details == null || details.Count == 0)
            throw new ArgumentException("Withdrawal order must have at least one item.");

        var withdrawalOrder = new WithdrawalOrder
        {
            WarehouseId = warehouseId,
            CustomerId = customerId,
            OrderNumber = orderNumber,
            OrderDate = orderDate,
            WithdrawalOrderDetails = details
        };

        await _unitOfWork.WithdrawalOrders.AddAsync(withdrawalOrder);
        await _unitOfWork.SaveAsync();
    }
}

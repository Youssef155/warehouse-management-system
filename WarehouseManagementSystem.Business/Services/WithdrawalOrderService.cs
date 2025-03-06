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

    public IEnumerable<WithdrawalOrder> GetAllWithdrawalOrders() => _unitOfWork.WithdrawalOrders.GetAll();

    public WithdrawalOrder GetWithdrawalOrderById(int id) => _unitOfWork.WithdrawalOrders.GetById(id);

    public void CreateWithdrawalOrder(int warehouseId, int customerId, string orderNumber, DateTime orderDate, List<WithdrawalOrderDetail> details)
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

        _unitOfWork.WithdrawalOrders.Add(withdrawalOrder);
        _unitOfWork.Save();
    }
}

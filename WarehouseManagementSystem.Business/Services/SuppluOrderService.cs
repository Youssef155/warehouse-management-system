﻿
using System;
using System.Collections.Generic;
using WarehouseManagementSystem.Business.Interfaces;
using WarehouseManagementSystem.Data.Models;
using WarehouseManagementSystem.Data.UOW.Interfaces;

namespace WarehouseManagementSystem.Business.Services;


public class SupplyOrderService : ISupplyOrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public SupplyOrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<SupplyOrder>> GetAllSupplyOrdersAsync() => 
        await _unitOfWork.SupplyOrders.GetAllAsync();

    public async Task<SupplyOrder> GetSupplyOrderByIdAsync(int id) => 
        await _unitOfWork.SupplyOrders.GetByIdAsync(id);

    public async Task CreateSupplyOrderAsync(int warehouseId, int supplierId, string orderNumber, DateTime orderDate, List<SupplyOrderDetail> details)
    {
        if (details == null || details.Count == 0)
            throw new ArgumentException("Supply order must have at least one item.");

        var supplyOrder = new SupplyOrder
        {
            WarehouseId = warehouseId,
            SupplierId = supplierId,
            OrderNumber = orderNumber,
            OrderDate = orderDate,
            SupplyOrderDetails = details
        };

        await _unitOfWork.SupplyOrders.AddAsync(supplyOrder);
        await _unitOfWork.SaveAsync();
    }
}

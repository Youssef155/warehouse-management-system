
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

    public IEnumerable<SupplyOrder> GetAllSupplyOrders() => _unitOfWork.SupplyOrders.GetAll();

    public SupplyOrder GetSupplyOrderById(int id) => _unitOfWork.SupplyOrders.GetById(id);

    public void CreateSupplyOrder(int warehouseId, int supplierId, string orderNumber, DateTime orderDate, List<SupplyOrderDetail> details)
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

        _unitOfWork.SupplyOrders.Add(supplyOrder);
        _unitOfWork.Save();
    }
}

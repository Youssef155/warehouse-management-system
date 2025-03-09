
using System;
using System.Collections.Generic;
using WarehouseManagementSystem.Business.Interfaces;
using WarehouseManagementSystem.Core.DTOs;
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

    public async Task<List<SupplyOrderDto>> GetAllSupplyOrdersWithDetailsAsync()
    {
        var orders = await _unitOfWork.SupplyOrders
            .GetAllWithIncludesAsync(o => o.Supplier, o => o.Warehouse, o => o.SupplyOrderDetails);

        return orders.SelectMany(order => order.SupplyOrderDetails.Select(detail => new SupplyOrderDto
        {
            OrderId = order.Id,
            OrderNumber = order.OrderNumber,
            OrderDate = order.OrderDate,
            SupplierName = order.Supplier.Name,
            WarehouseName = order.Warehouse.Name,
            ItemName = detail.Item.Name,
            Quantity = detail.Quantity,
            ProductionDate = detail.ProductionDate,
            ExpirationDate = detail.ExpirationDate
        })).ToList();
    }


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

    public async Task AddSupplyOrderAsync(SupplyOrderDto orderDto)
    {
        using var transaction = await _unitOfWork.BeginTransactionAsync();
        try
        {
            // Add the new item
            var newItem = new Item
            {
                Code = orderDto.ItemCode,
                Name = orderDto.ItemName,
                MeasurementUnit = orderDto.MeasurementUnit
            };

            await _unitOfWork.Items.AddAsync(newItem);
            await _unitOfWork.SaveAsync();

            // Add the supply order
            var newOrder = new SupplyOrder
            {
                SupplierId = orderDto.SupplierId,
                WarehouseId = orderDto.WarehouseId,
                OrderNumber = "SO-" + Guid.NewGuid().ToString().Substring(0, 6),
                OrderDate = DateTime.Now,
                SupplyOrderDetails = new List<SupplyOrderDetail>
            {
                new SupplyOrderDetail
                {
                    ItemId = newItem.Id,
                    Quantity = orderDto.Quantity,
                    ProductionDate = orderDto.ProductionDate,
                    ExpirationDate = orderDto.ExpirationDate
                }
            }
            };

            await _unitOfWork.SupplyOrders.AddAsync(newOrder);
            await _unitOfWork.SaveAsync();

            // Add the stock entry
            var stockItem = new StockItem
            {
                WarehouseId = orderDto.WarehouseId,
                ItemId = newItem.Id,
                Quantity = orderDto.Quantity,
                ProductionDate = orderDto.ProductionDate,
                ExpirationDate = orderDto.ExpirationDate
            };

            await _unitOfWork.StockItems.AddAsync(stockItem);
            await _unitOfWork.SaveAsync();

            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new Exception("Error while adding supply order: " + ex.Message);
        }
    }


}

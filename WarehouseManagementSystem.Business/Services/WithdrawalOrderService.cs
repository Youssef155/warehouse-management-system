using System;
using System.Collections.Generic;
using WarehouseManagementSystem.Business.Interfaces;
using WarehouseManagementSystem.Core.DTOs;
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

    public async Task<IEnumerable<WithdrawalOrderDTO>> GetAllWithdrawalOrdersAsync()
    {
        var orders = await _unitOfWork.WithdrawalOrders.GetAllAsync();
        var result = orders.Select(order => new WithdrawalOrderDTO
        {
            OrderId = order.Id,
            OrderDate = order.OrderDate,
            WarehouseId = order.WarehouseId,
            WarehouseName = order.Warehouse?.Name,
            Items = order.WithdrawalOrderDetails.Select(detail => new WithdrawalOrderItemDTO
            {
                ItemId = detail.ItemId,
                ItemName = detail.Item?.Name,
                Quantity = detail.Quantity
            }).ToList()
        });

        return result;
    }

    public async Task<WithdrawalOrderDTO> GetWithdrawalOrderByIdAsync(int id)
    {
        var order = await _unitOfWork.WithdrawalOrders.GetByIdAsync(id);
        if (order == null) return null;

        var result = new WithdrawalOrderDTO
        {
            OrderId = order.Id,
            OrderDate = order.OrderDate,
            WarehouseId = order.WarehouseId,
            WarehouseName = order.Warehouse?.Name,
            Items = order.WithdrawalOrderDetails.Select(detail => new WithdrawalOrderItemDTO
            {
                ItemId = detail.ItemId,
                ItemName = detail.Item?.Name,
                Quantity = detail.Quantity
            }).ToList()
        };

        return result;
    }


    public async Task CreateOrderAsync(WithdrawalOrderDTO orderDto)
    {
        foreach (var item in orderDto.Items)
        {
            var stockItem = await _unitOfWork.StockItems.GetByIdAsync(item.ItemId);

            if (stockItem == null || stockItem.Quantity < item.Quantity)
                throw new InvalidOperationException($"Insufficient quantity for item: {item.ItemName}");

            // Deduct the quantity
            stockItem.Quantity -= item.Quantity;
            await _unitOfWork.StockItems.UpdateAsync(stockItem);
        }

        var order = new WithdrawalOrder
        {
            OrderDate = orderDto.OrderDate,
            WarehouseId = orderDto.WarehouseId,
            WithdrawalOrderDetails = orderDto.Items.Select(item => new WithdrawalOrderDetail
            {
                ItemId = item.ItemId,
                Quantity = item.Quantity
            }).ToList()
        };

        await _unitOfWork.WithdrawalOrders.AddAsync(order);
    }

    public async Task UpdateOrderAsync(WithdrawalOrderDTO orderDto)
    {
        var existingOrder = await _unitOfWork.WithdrawalOrders.GetByIdAsync(orderDto.OrderId);
        if (existingOrder == null) return;

        existingOrder.OrderDate = orderDto.OrderDate;
        existingOrder.WarehouseId = orderDto.WarehouseId;

        // Clear existing details and add updated ones
        existingOrder.WithdrawalOrderDetails.Clear();
        foreach (var item in orderDto.Items)
        {
            existingOrder.WithdrawalOrderDetails.Add(new WithdrawalOrderDetail
            {
                ItemId = item.ItemId,
                Quantity = item.Quantity
            });
        }

        await _unitOfWork.WithdrawalOrders.UpdateAsync(existingOrder);
    }

    public async Task DeleteAsync(int id)
    {
        var order = await _unitOfWork.WithdrawalOrders.GetByIdAsync(id);
        await _unitOfWork.WithdrawalOrders.DeleteAsync(order);
    }

    public async Task<IEnumerable<WithdrawalOrderDTO>> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
    {
        var orders = await _unitOfWork.WithdrawalOrders.GetByDateRangeAsync(startDate, endDate);
        var result = orders.Select(order => new WithdrawalOrderDTO
        {
            OrderId = order.Id,
            OrderDate = order.OrderDate,
            WarehouseId = order.WarehouseId,
            WarehouseName = order.Warehouse?.Name,
            Items = order.WithdrawalOrderDetails.Select(detail => new WithdrawalOrderItemDTO
            {
                ItemId = detail.ItemId,
                ItemName = detail.Item?.Name,
                Quantity = detail.Quantity
            }).ToList()
        });

        return result;
    }

    public async Task<IEnumerable<WithdrawalOrderDTO>> GetOrdersByWarehouse(int warehouseId)
    {
        var orders = await _unitOfWork.WithdrawalOrders.GetByWarehouseAsync(warehouseId);
        var result = orders.Select(order => new WithdrawalOrderDTO
        {
            OrderId = order.Id,
            OrderDate = order.OrderDate,
            WarehouseId = order.WarehouseId,
            WarehouseName = order.Warehouse?.Name,
            Items = order.WithdrawalOrderDetails.Select(detail => new WithdrawalOrderItemDTO
            {
                ItemId = detail.ItemId,
                ItemName = detail.Item?.Name,
                Quantity = detail.Quantity
            }).ToList()
        });

        return result;
    }

}

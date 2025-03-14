﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using WarehouseManagementSystem.Business.Interfaces;
using WarehouseManagementSystem.Core.DTOs;
using WarehouseManagementSystem.Data.Models;
using WarehouseManagementSystem.Data.UOW.Interfaces;

namespace WarehouseManagementSystem.Business.Services;



public class ItemService : IItemService
{
    private readonly IUnitOfWork _unitOfWork;

    public ItemService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Item>> GetAllItemsAsync()
    {
        return await _unitOfWork.Items.GetAllAsync();
    }

    public async Task<List<ItemWarehouseDto>> GetItemsInWarehousesAsync()
    {
        var stockItems = await _unitOfWork.StockItemRepository
            .GetAllWithIncludesAsync(s => s.Item, s => s.Warehouse);

        var result = stockItems.Select(s => new ItemWarehouseDto
        {
            ItemId = s.Item.Id,
            ItemName = s.Item.Name,
            WarehouseName = s.Warehouse.Name,
            Quantity = s.Quantity,
            ItemCode = s.Item.Code,
            ProductionDate = s.ProductionDate,
            ExpirationDate = s.ExpirationDate,
            Units = s.Item.ItemUnits.Select(iu => new ItemUnitDto
            {
                UnitId = iu.Unit.Id,
                UnitName = iu.Unit.Name,
                ConversionFactor = iu.ConversionFactor
            }).ToList()
        }).ToList();

        return result;
    }

    public async Task<List<ItemWarehouseDto>> GetItemsByWarehousesAsync(List<int> warehouseIds)
    {
        var query = _unitOfWork.StockItemRepository
        .GetQueryable()
        .Where(s => warehouseIds.Contains(s.WarehouseId))
        .Include(s => s.Item)
        .Include(s => s.Warehouse);

        var stockItems = await query.ToListAsync();

        var result = stockItems.Select(s => new ItemWarehouseDto
        {
            ItemId = s.Item.Id,
            ItemName = s.Item.Name,
            WarehouseName = s.Warehouse.Name,
            Quantity = s.Quantity,
            ItemCode = s.Item.Code,
            ProductionDate = s.ProductionDate,
            ExpirationDate = s.ExpirationDate,
            Units = s.Item.ItemUnits.Select(iu => new ItemUnitDto
            {
                UnitId = iu.Unit.Id,
                UnitName = iu.Unit.Name,
                ConversionFactor = iu.ConversionFactor
            }).ToList()
        }).ToList();

        return result;
    }

    public async Task<List<ItemWarehouseDto>> GetItemsByWarehouseIdAsync(int warehouseId)
    {
        var query = _unitOfWork.StockItemRepository
        .GetQueryable()
        .Where(s => s.WarehouseId == warehouseId)
        .Include(s => s.Item)
        .Include(s => s.Warehouse);

        var stockItems = await query.ToListAsync();

        var result = stockItems.Select(s => new ItemWarehouseDto
        {
            ItemId = s.Item.Id,
            ItemName = s.Item.Name,
            WarehouseName = s.Warehouse.Name,
            Quantity = s.Quantity,
            ItemCode = s.Item.Code,
            ProductionDate = s.ProductionDate,
            ExpirationDate = s.ExpirationDate,
            Units = s.Item.ItemUnits.Select(iu => new ItemUnitDto
            {
                UnitId = iu.Unit.Id,
                UnitName = iu.Unit.Name,
                ConversionFactor = iu.ConversionFactor
            }).ToList()
        }).ToList();
        return result;
    }


    public async Task<Item> GetItemByIdAsync(int id) => 
        await _unitOfWork.Items.GetByIdAsync(id);

    public async Task AddItemAsync(string code, string name, string measurementUnit)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Item name cannot be empty.");

        var item = new Item { Code = code, Name = name, MeasurementUnit = measurementUnit };
        await _unitOfWork.Items.AddAsync(item);
        await _unitOfWork.SaveAsync();
    }

    public async Task AddNewItemToWarehouseAsync(string itemCode, string itemName, int warehouseId, int quantity, string measurementUnit)
    {
        if (string.IsNullOrWhiteSpace(itemName))
            throw new ArgumentException("Item name cannot be empty.");

        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        // Create a new item
        var newItem = new Item
        {
            Code = itemCode,
            Name = itemName,
            MeasurementUnit = measurementUnit
        };

        // Add the new item to the database
        await _unitOfWork.Items.AddAsync(newItem);
        await _unitOfWork.SaveAsync();

        // Create a stock entry for the warehouse
        var stockItem = new StockItem
        {
            ItemId = newItem.Id,
            WarehouseId = warehouseId,
            Quantity = quantity
        };

        // Add stock item to the database
        await _unitOfWork.StockItemRepository.AddAsync(stockItem);
        await _unitOfWork.SaveAsync();
    }

    public async Task UpdateItemAsync(int id, string code, string name, string measurementUnit)
    {
        var item = await _unitOfWork.Items.GetByIdAsync(id);
        if (item == null) throw new Exception("Item not found.");

        item.Code = code;
        item.Name = name;
        item.MeasurementUnit = measurementUnit;

        await _unitOfWork.Items.UpdateAsync(item);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteItemAsync(int id)
    {
        var item = await _unitOfWork.Items.GetByIdAsync(id);
        if (item == null) throw new Exception("Item not found.");

        await _unitOfWork.Items.DeleteAsync(item);
        await _unitOfWork.SaveAsync();
    }

    public async Task<DataTable> GetItemsCloseToExpirationAsync(int daysThreshold)
    {
        var dataTable = new DataTable();
        dataTable.Columns.Add("ItemName");
        dataTable.Columns.Add("WarehouseName");
        dataTable.Columns.Add("Quantity");
        dataTable.Columns.Add("ProductionDate");
        dataTable.Columns.Add("ExpirationDate");
        dataTable.Columns.Add("DaysUntilExpiration");

        var currentDate = DateTime.Now;

        var stockItems = await _unitOfWork.StockItemRepository
            .GetAllWithIncludesAsync( si => si.Item, si => si.Warehouse);

        var filteredItems = stockItems
            .Where(si => (si.ExpirationDate - currentDate).TotalDays <= daysThreshold)
            .ToList();

        foreach (var item in filteredItems)
        {
            var daysUntilExpiration = (item.ExpirationDate - currentDate).Days;

            dataTable.Rows.Add(
                item.Item.Name,
                item.Warehouse.Name,
                item.Quantity,
                item.ProductionDate.ToShortDateString(),
                item.ExpirationDate.ToShortDateString(),
                daysUntilExpiration
            );
        }

        return dataTable;
    }

}

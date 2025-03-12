using System;
using System.Collections.Generic;
using System.Data;
using WarehouseManagementSystem.Business.Interfaces;
using WarehouseManagementSystem.Data.Models;
using WarehouseManagementSystem.Data.UOW.Interfaces;

namespace WarehouseManagementSystem.Business.Services;



public class WarehouseService : IWarehouseService
{
    private readonly IUnitOfWork _unitOfWork;

    public WarehouseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Warehouse>> GetAllWarehousesAsync()
    {
        return await _unitOfWork.Warehouses.GetAllAsync();
    }

    public async Task<Warehouse> GetWarehouseByIdAsync(int id)
    {
        return await _unitOfWork.Warehouses.GetByIdAsync(id);
    }

    public async Task AddWarehouseAsync(string name, string address, string manager)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Warehouse name cannot be empty.");

        var warehouse = new Warehouse { Name = name, Address = address, Manager = manager };
        await _unitOfWork.Warehouses.AddAsync(warehouse);
        await _unitOfWork.SaveAsync();
    }

    public async Task UpdateWarehouseAsync(int id, string name, string address, string manager)
    {
        var warehouse = await _unitOfWork.Warehouses.GetByIdAsync(id);
        if (warehouse == null)
            throw new Exception("Warehouse not found.");

        warehouse.Name = name;
        warehouse.Address = address;
        warehouse.Manager = manager;

        await _unitOfWork.Warehouses.UpdateAsync(warehouse);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteWarehouseAsync(int id)
    {
        var warehouse = await _unitOfWork.Warehouses.GetByIdAsync(id);
        if (warehouse == null)
            throw new Exception("Warehouse not found.");

        await _unitOfWork.Warehouses.DeleteAsync(warehouse);
        await _unitOfWork.SaveAsync();
    }

    // reports
    public async Task<DataTable> GetWarehouseStatusReport(int warehouseId)
    {
        var dataTable = new DataTable();
        dataTable.Columns.Add("ItemName");
        dataTable.Columns.Add("Quantity");
        dataTable.Columns.Add("ProductionDate");
        dataTable.Columns.Add("ExpirationDate");

        var stockItems = await _unitOfWork.StockItemRepository.GetStockItemsWithItemAsync(warehouseId);

        foreach (var item in stockItems)
        {
            dataTable.Rows.Add(
                item?.Item?.Name ?? "Unknown",
                item.Quantity,
                item.ProductionDate.ToShortDateString(),
                item.ExpirationDate.ToShortDateString()
            );
        }

        return dataTable;
    }

    public async Task<DataTable> GetItemsReport(List<int> warehouseIds)
    {
        var dataTable = new DataTable();
        dataTable.Columns.Add("WarehouseName");
        dataTable.Columns.Add("ItemName");
        dataTable.Columns.Add("Quantity");
        dataTable.Columns.Add("ProductionDate");
        dataTable.Columns.Add("ExpirationDate");

        var stockItems = await _unitOfWork.StockItems.GetAllWithIncludesAsync(si => si.Item, si => si.Warehouse);

        // Filter the stock items based on the selected warehouse IDs
        var filteredStockItems = stockItems.Where(si => warehouseIds.Contains(si.WarehouseId)).ToList();

        foreach (var item in stockItems)
        {
            string warehouseName = item?.Warehouse?.Name ?? "Unknown";
            string itemName = item?.Item?.Name ?? "Unknown";
            int quantity = item?.Quantity ?? 0;
            string productionDate = item?.ProductionDate.ToShortDateString() ?? "N/A";
            string expirationDate = item?.ExpirationDate.ToShortDateString() ?? "N/A";

            dataTable.Rows.Add(warehouseName, itemName, quantity, productionDate, expirationDate);
        }

        return dataTable;
    }

    public async Task<DataTable> GetItemsInWarehouseForPeriod(int warehouseId, DateTime fromDate, DateTime toDate)
    {
        var dataTable = new DataTable();
        dataTable.Columns.Add("WarehouseName");
        dataTable.Columns.Add("ItemName");
        dataTable.Columns.Add("Quantity");
        dataTable.Columns.Add("ProductionDate");
        dataTable.Columns.Add("ExpirationDate");
        dataTable.Columns.Add("DaysInWarehouse");

        var stockItems = await _unitOfWork.StockItemRepository
            .GetAllWithIncludesAsync( si => si.Item, si => si.Warehouse);

        stockItems = stockItems.Where(si => si.WarehouseId == warehouseId).ToList();

        foreach (var item in stockItems)
        {
            // Find the corresponding supply order detail using ItemId and ProductionDate
            var supplyOrderDetail = await _unitOfWork.SupplyOrderDetails
                .FindAsync(sod => sod.ItemId == item.ItemId && sod.ProductionDate == item.ProductionDate);

            var orderDate = supplyOrderDetail.FirstOrDefault()?.SupplyOrder?.OrderDate ?? DateTime.MinValue;

            // Calculate how long the item has been in the warehouse
            var daysInWarehouse = (DateTime.Now - orderDate).Days;

            // Check if the item has been in the warehouse within the specified period
            if (orderDate >= fromDate && orderDate <= toDate)
            {
                dataTable.Rows.Add(
                    item.Warehouse.Name,
                    item.Item.Name,
                    item.Quantity,
                    item.ProductionDate.ToShortDateString(),
                    item.ExpirationDate.ToShortDateString(),
                    daysInWarehouse
                );
            }
        }

        return dataTable;
    }



}

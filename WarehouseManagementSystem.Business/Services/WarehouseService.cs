using System;
using System.Collections.Generic;
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
}

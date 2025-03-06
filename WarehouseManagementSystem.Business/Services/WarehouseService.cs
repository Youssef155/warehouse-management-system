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

    public IEnumerable<Warehouse> GetAllWarehouses()
    {
        return _unitOfWork.Warehouses.GetAll();
    }

    public Warehouse GetWarehouseById(int id)
    {
        return _unitOfWork.Warehouses.GetById(id);
    }

    public void AddWarehouse(string name, string address, string manager)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Warehouse name cannot be empty.");

        var warehouse = new Warehouse { Name = name, Address = address, Manager = manager };
        _unitOfWork.Warehouses.Add(warehouse);
        _unitOfWork.Save();
    }

    public void UpdateWarehouse(int id, string name, string address, string manager)
    {
        var warehouse = _unitOfWork.Warehouses.GetById(id);
        if (warehouse == null)
            throw new Exception("Warehouse not found.");

        warehouse.Name = name;
        warehouse.Address = address;
        warehouse.Manager = manager;

        _unitOfWork.Warehouses.Update(warehouse);
        _unitOfWork.Save();
    }

    public void DeleteWarehouse(int id)
    {
        var warehouse = _unitOfWork.Warehouses.GetById(id);
        if (warehouse == null)
            throw new Exception("Warehouse not found.");

        _unitOfWork.Warehouses.Delete(warehouse);
        _unitOfWork.Save();
    }
}

using System;
using System.Collections.Generic;
using WarehouseManagementSystem.Business.Interfaces;
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

    public IEnumerable<Item> GetAllItems() => _unitOfWork.Items.GetAll();

    public Item GetItemById(int id) => _unitOfWork.Items.GetById(id);

    public void AddItem(string code, string name, string measurementUnit)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Item name cannot be empty.");

        var item = new Item { Code = code, Name = name, MeasurementUnit = measurementUnit };
        _unitOfWork.Items.Add(item);
        _unitOfWork.Save();
    }

    public void UpdateItem(int id, string code, string name, string measurementUnit)
    {
        var item = _unitOfWork.Items.GetById(id);
        if (item == null) throw new Exception("Item not found.");

        item.Code = code;
        item.Name = name;
        item.MeasurementUnit = measurementUnit;

        _unitOfWork.Items.Update(item);
        _unitOfWork.Save();
    }

    public void DeleteItem(int id)
    {
        var item = _unitOfWork.Items.GetById(id);
        if (item == null) throw new Exception("Item not found.");

        _unitOfWork.Items.Delete(item);
        _unitOfWork.Save();
    }
}

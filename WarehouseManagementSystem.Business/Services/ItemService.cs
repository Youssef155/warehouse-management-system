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

    public async Task<IEnumerable<Item>> GetAllItemsAsync()
    {
        return await _unitOfWork.Items.GetAllAsync();
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
}

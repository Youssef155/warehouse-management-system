using System.Collections.Generic;
using WarehouseManagementSystem.Data.Models;

namespace WarehouseManagementSystem.Business.Interfaces;


public interface IItemService
{
    Task<IEnumerable<Item>> GetAllItemsAsync();
    Task<Item> GetItemByIdAsync(int id);
    Task AddItemAsync(string code, string name, string measurementUnit);
    Task UpdateItemAsync(int id, string code, string name, string measurementUnit);
    Task DeleteItemAsync(int id);
}

using System.Collections.Generic;
using WarehouseManagementSystem.Data.Models;

namespace WarehouseManagementSystem.Business.Interfaces;


public interface IItemService
{
    IEnumerable<Item> GetAllItems();
    Item GetItemById(int id);
    void AddItem(string code, string name, string measurementUnit);
    void UpdateItem(int id, string code, string name, string measurementUnit);
    void DeleteItem(int id);
}

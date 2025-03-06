using System.Collections.Generic;
using WarehouseManagementSystem.Data.Models;

namespace WarehouseManagementSystem.Business.Interfaces;

public interface IWarehouseService
{
    IEnumerable<Warehouse> GetAllWarehouses();
    Warehouse GetWarehouseById(int id);
    void AddWarehouse(string name, string address, string manager);
    void UpdateWarehouse(int id, string name, string address, string manager);
    void DeleteWarehouse(int id);
}


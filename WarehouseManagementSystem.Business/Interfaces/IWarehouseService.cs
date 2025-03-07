using System.Collections.Generic;
using WarehouseManagementSystem.Data.Models;

namespace WarehouseManagementSystem.Business.Interfaces;

public interface IWarehouseService
{
    Task<IEnumerable<Warehouse>> GetAllWarehousesAsync();
    Task<Warehouse> GetWarehouseByIdAsync(int id);
    Task AddWarehouseAsync(string name, string address, string manager);
    Task UpdateWarehouseAsync(int id, string name, string address, string manager);
    Task DeleteWarehouseAsync(int id);
}


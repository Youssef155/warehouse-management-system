using System.Collections.Generic;
using WarehouseManagementSystem.Data.Models;

namespace WarehouseManagementSystem.Business.Interfaces;


public interface ISupplierService
{
    Task<IEnumerable<Supplier>> GetAllSuppliersAsync();
    Task<Supplier> GetSupplierByIdAsync(int id);
    Task AddSupplierAsync(string name, string phone, string email,
        string fax, string mobile, string website);
    Task UpdateSupplierAsync(int id, string name, string phone, string email,
        string fax, string mobile, string website);
    Task DeleteSupplierAsync(int id);
}

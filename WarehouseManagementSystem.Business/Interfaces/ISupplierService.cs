using System.Collections.Generic;
using WarehouseManagementSystem.Data.Models;

namespace WarehouseManagementSystem.Business.Interfaces;


public interface ISupplierService
{
    IEnumerable<Supplier> GetAllSuppliers();
    Supplier GetSupplierById(int id);
    void AddSupplier(string name, string phone, string email, string website);
    void UpdateSupplier(int id, string name, string phone, string email, string website);
    void DeleteSupplier(int id);
}

using System;
using System.Collections.Generic;
using WarehouseManagementSystem.Business.Interfaces;
using WarehouseManagementSystem.Data.Models;
using WarehouseManagementSystem.Data.UOW.Interfaces;

namespace WarehouseManagementSystem.Business.Services;


public class SupplierService : ISupplierService
{
    private readonly IUnitOfWork _unitOfWork;

    public SupplierService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync() => 
        await _unitOfWork.Suppliers.GetAllAsync();

    public async Task<Supplier> GetSupplierByIdAsync(int id) => 
        await _unitOfWork.Suppliers.GetByIdAsync(id);

    public async Task AddSupplierAsync(string name, string phone, string email, 
        string fax, string mobile, string website)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Supplier name cannot be empty.");

        var supplier = new Supplier 
        { 
            Name = name, 
            Phone = phone, 
            Email = email, 
            Fax = fax,
            Mobile = mobile,
            Website = website 
        };
        await _unitOfWork.Suppliers.AddAsync(supplier);
        await _unitOfWork.SaveAsync();
    }

    public async Task UpdateSupplierAsync(int id, string name, string phone, string email,
        string fax, string mobile, string website)
    {
        var supplier = await _unitOfWork.Suppliers.GetByIdAsync(id);
        if (supplier == null) throw new Exception("Supplier not found.");

        supplier.Name = name;
        supplier.Phone = phone;
        supplier.Email = email;
        supplier.Website = website;

        await _unitOfWork.Suppliers.UpdateAsync(supplier);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteSupplierAsync(int id)
    {
        var supplier = await _unitOfWork.Suppliers.GetByIdAsync(id);
        if (supplier == null) throw new Exception("Supplier not found.");

        await _unitOfWork.Suppliers.DeleteAsync(supplier);
        await _unitOfWork.SaveAsync();
    }
}

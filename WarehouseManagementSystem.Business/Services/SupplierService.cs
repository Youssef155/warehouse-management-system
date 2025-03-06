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

    public IEnumerable<Supplier> GetAllSuppliers() => _unitOfWork.Suppliers.GetAll();

    public Supplier GetSupplierById(int id) => _unitOfWork.Suppliers.GetById(id);

    public void AddSupplier(string name, string phone, string email, string website)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Supplier name cannot be empty.");

        var supplier = new Supplier { Name = name, Phone = phone, Email = email, Website = website };
        _unitOfWork.Suppliers.Add(supplier);
        _unitOfWork.Save();
    }

    public void UpdateSupplier(int id, string name, string phone, string email, string website)
    {
        var supplier = _unitOfWork.Suppliers.GetById(id);
        if (supplier == null) throw new Exception("Supplier not found.");

        supplier.Name = name;
        supplier.Phone = phone;
        supplier.Email = email;
        supplier.Website = website;

        _unitOfWork.Suppliers.Update(supplier);
        _unitOfWork.Save();
    }

    public void DeleteSupplier(int id)
    {
        var supplier = _unitOfWork.Suppliers.GetById(id);
        if (supplier == null) throw new Exception("Supplier not found.");

        _unitOfWork.Suppliers.Delete(supplier);
        _unitOfWork.Save();
    }
}

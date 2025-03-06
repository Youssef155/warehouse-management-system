using System;
using System.Collections.Generic;
using WarehouseManagementSystem.Business.Interfaces;
using WarehouseManagementSystem.Data.Models;
using WarehouseManagementSystem.Data.UOW.Interfaces;

namespace WarehouseManagementSystem.Business.Services;


public class CustomerService : ICustomerService
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<Customer> GetAllCustomers() => _unitOfWork.Customers.GetAll();

    public Customer GetCustomerById(int id) => _unitOfWork.Customers.GetById(id);

    public void AddCustomer(string name, string phone, string email)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Customer name cannot be empty.");

        var customer = new Customer { Name = name, Phone = phone, Email = email };
        _unitOfWork.Customers.Add(customer);
        _unitOfWork.Save();
    }

    public void UpdateCustomer(int id, string name, string phone, string email)
    {
        var customer = _unitOfWork.Customers.GetById(id);
        if (customer == null) throw new Exception("Customer not found.");

        customer.Name = name;
        customer.Phone = phone;
        customer.Email = email;

        _unitOfWork.Customers.Update(customer);
        _unitOfWork.Save();
    }

    public void DeleteCustomer(int id)
    {
        var customer = _unitOfWork.Customers.GetById(id);
        if (customer == null) throw new Exception("Customer not found.");

        _unitOfWork.Customers.Delete(customer);
        _unitOfWork.Save();
    }
}

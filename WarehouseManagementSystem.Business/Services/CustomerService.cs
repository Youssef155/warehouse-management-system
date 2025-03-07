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

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync() =>
        await _unitOfWork.Customers.GetAllAsync();

    public async Task<Customer> GetCustomerByIdAsync(int id) => 
        await _unitOfWork.Customers.GetByIdAsync(id);

    public async Task AddCustomerAsync(string name, string phone, string email)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Customer name cannot be empty.");

        var customer = new Customer { Name = name, Phone = phone, Email = email };
        await _unitOfWork.Customers.AddAsync(customer);
        await _unitOfWork.SaveAsync();
    }

    public async Task UpdateCustomerAsync(int id, string name, string phone, string email)
    {
        var customer = await _unitOfWork.Customers.GetByIdAsync(id);
        if (customer == null) throw new Exception("Customer not found.");

        customer.Name = name;
        customer.Phone = phone;
        customer.Email = email;

        await _unitOfWork.Customers.UpdateAsync(customer);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteCustomerAsync(int id)
    {
        var customer = await _unitOfWork.Customers.GetByIdAsync(id);
        if (customer == null) throw new Exception("Customer not found.");

        await _unitOfWork.Customers.DeleteAsync(customer);
        await _unitOfWork.SaveAsync();
    }
}

using System.Collections.Generic;
using WarehouseManagementSystem.Data.Models;

namespace WarehouseManagementSystem.Business.Interfaces;


public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task<Customer> GetCustomerByIdAsync(int id);
    Task AddCustomerAsync(string name, string phone, string email);
    Task UpdateCustomerAsync(int id, string name, string phone, string email);
    Task DeleteCustomerAsync(int id);
}

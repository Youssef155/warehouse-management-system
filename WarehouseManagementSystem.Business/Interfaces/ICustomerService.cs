using System.Collections.Generic;
using WarehouseManagementSystem.Data.Models;

namespace WarehouseManagementSystem.Business.Interfaces;


public interface ICustomerService
{
    IEnumerable<Customer> GetAllCustomers();
    Customer GetCustomerById(int id);
    void AddCustomer(string name, string phone, string email);
    void UpdateCustomer(int id, string name, string phone, string email);
    void DeleteCustomer(int id);
}

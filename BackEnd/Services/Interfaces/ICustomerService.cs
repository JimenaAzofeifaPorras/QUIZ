using BackEnd.Models;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerModel> GetCustomers();
        CustomerModel GetById(int id);
        bool AddCustomer(CustomerModel customer);
        bool UpdateCustomer(CustomerModel customer);
        bool DeleteCustomer(CustomerModel customer);


    }
}

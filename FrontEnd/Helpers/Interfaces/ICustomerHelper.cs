using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ICustomerHelper
    {
        List<CustomerViewModel> GetCustomers();
        CustomerViewModel GetCustomer(int id);
        CustomerViewModel AddCustomer(CustomerViewModel customer);
        CustomerViewModel DeleteCustomer(int id);
        CustomerViewModel UpdateCustomer(CustomerViewModel customer);

    }
}
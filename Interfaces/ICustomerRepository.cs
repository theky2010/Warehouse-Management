using WareHouseManagment.Dto;
using WareHouseManagment.Models;

namespace WareHouseManagment.Interfaces
{
    public interface ICustomerRepository
    {
        ICollection<Customer> GetCustomers();
        Customer GetCustomer(int id);
        ICollection<Customer> GetCustomer(string name);
        Customer GetCustomerTrimToUpper(CustomerDto customerCreate);
        bool CustomerExists(int customerId);
        bool CreateCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(Customer customer);
        bool Save();

    }
}

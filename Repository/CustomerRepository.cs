using WareHouseManagment.Data;
using WareHouseManagment.Dto;
using WareHouseManagment.Interfaces;
using WareHouseManagment.Models;
using WareHouseManagment.Utilities;

namespace WareHouseManagment.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext context)
        {
            _context = context;
        }
        public bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
        
        public ICollection<Customer> GetCustomers()
        {
            return _context.Customers.OrderBy(e => e.Id).ToList();
        }

        public Customer GetCustomer(int id)
        {
            return _context.Customers.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Customer> GetCustomer(string name)
        {
            string normalizedKeyword = StringUtilities.RemoveDiacritics(name.ToLower());
            return _context.Customers.AsEnumerable().Where(e => e.Name.ToLower().Contains(name.ToLower()) || StringUtilities.RemoveDiacritics(e.Name.ToLower()).Contains(normalizedKeyword)).ToList();
        }
        public Customer GetCustomerTrimToUpper(CustomerDto customerCreate)
        {
            return GetCustomers().Where(c => c.Name.Trim().ToUpper() == customerCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();
        }

        public bool CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            return Save();
        }

        public bool UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            return Save();
        }

        public bool DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true:false;
        }
    }
}

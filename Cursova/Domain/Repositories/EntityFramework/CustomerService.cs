using Cursova.Domain.Repositories.Abstract;
using Cursova.Models;
using Cursova.ViewModels;

namespace Cursova.Domain.Repositories.EntityFramework
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;
        public CustomerService(AppDbContext context) { 
            _context = context;
        }
        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
        public void UpdateCustomer(Customer customer)
        {
            var existingCustomer = _context.Customers.Find(customer.CustomerId);
            if (existingCustomer != null)
            {
                existingCustomer.CustomerName = customer.CustomerName;
                existingCustomer.Address = customer.Address;
                existingCustomer.Phone = customer.Phone;
                _context.SaveChanges();
            }
        }
        public void DeleteCustomer(int customerId)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                Console.WriteLine("Customer removed from context.");
                _context.SaveChanges();
                Console.WriteLine("Changes saved to the database.");
            }
            else
            {
                // 
                Console.WriteLine("Customer not found.");
            }
        }

        public List<Customer> GetCustomers(CustomerViewModel filter)
        {
            var query = _context.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(filter.CustomerName))
            {
                query = query.Where(c => c.CustomerName.Contains(filter.CustomerName));
            }

            if (!string.IsNullOrEmpty(filter.Address))
            {
                query = query.Where(c => c.Address.Contains(filter.Address));
            }

            if (!string.IsNullOrEmpty(filter.Phone))
            {
                query = query.Where(c => c.Phone.Contains(filter.Phone));
            }

            return query.ToList(); 
        }

        //1
        public List<Customer> GetMostActiveCustomer()
        {
            return _context.Customers
                .OrderByDescending(c => c.SalesDeals.Count)
                .Take(10)
                .ToList();
        }
        //3
        public List<Customer> GetCustomersByProductAndPeriod(int productId, DateTime startDate, DateTime endDate, int supplierId)
        {
            return _context.Customers
                .Where(c => c.SalesDeals.Any(sd => sd.FrStockId == productId
                                                    && sd.OrderDate >= startDate
                                                    && sd.OrderDate <= endDate
                                                    && sd.FrSupplierId == supplierId))
                .ToList();
        }

        public List<Customer> GetCustomersByProductAndPeriod(int productId, DateTime startDate, DateTime endDate)
        {
            return _context.Customers
                .Where(c => c.SalesDeals.Any(sd => sd.FrStockId == productId
                                                    && sd.OrderDate >= startDate
                                                    && sd.OrderDate <= endDate))
                .ToList();
        }

        public List<Customer> GetCustomersByProductAndPeriod(int productId, int supplierId)
        {
            return _context.Customers
                .Where(c => c.SalesDeals.Any(sd => sd.FrStockId == productId
                                                    && sd.FrSupplierId == supplierId))
                .ToList();
        }

        public List<Customer> GetCustomersByProductAndPeriod(int productId)
        {
            return _context.Customers
                .Where(c => c.SalesDeals.Any(sd => sd.FrStockId == productId))
                .ToList();
        }

        //9
        /*public List<Customer> GetCustomersByProductVolume(int productId, DateTime startDate, DateTime endDate, int? salesDeal)
        {
            throw new NotImplementedException();
        }*/

    }
}

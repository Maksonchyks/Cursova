using Cursova.Domain.Repositories.Abstract;
using Cursova.Models;
using System.Linq;

namespace Cursova.Domain.Repositories.EntityFramework
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;
        public CustomerService(AppDbContext context) { 
            _context = context;
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

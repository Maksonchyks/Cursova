using System.ComponentModel.DataAnnotations.Schema;

namespace Cursova.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public List<SalesDeal>? SalesDeals { get; set; }
    }
}

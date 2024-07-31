namespace Cursova.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Addresss { get; set; }
        public string Phone { get; set; }
        public List<Stock> Stocks { get; set; }
        public List<SalesDeal> SalesDeals { get; set; }
    }

}

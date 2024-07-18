namespace Cursova.Models
{
    public class SalesDeal
    {
        public int DealId { get; set; }
        public int FrStockId { get; set; }
        public int FrSupplierId { get; set; }
        public int FrCustomerId { get; set; }
        public int QuantitySold { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public Customer Customer { get; set; }
        public Stock Stock { get; set; }
        public Supplier Supplier { get; set; }
    }

}

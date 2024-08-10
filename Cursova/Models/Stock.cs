namespace Cursova.Models
{
    public class Stock
    {
        public int StockId { get; set; }
        public int FrSupplierId { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public Supplier? Supplier { get; set; }
        public List<SalesDeal>? SalesDeal { get; set; }
    }

}

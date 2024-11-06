using Cursova.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cursova.ViewModels
{
    public class StockViewModel
    {
        public string? ProductName { get; set; }
        public string? Unit { get; set; }
        public int? Quantity { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? SalePrice { get; set; }
    }
}

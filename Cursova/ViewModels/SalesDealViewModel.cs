using Cursova.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cursova.ViewModels
{
    public class SalesDealViewModel
    {
        public int QuantitySold { get; set; }
        public decimal TotalAmount { get; set; }

    }
}

using Cursova.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cursova.ViewModels
{
    public class SupplierViewModel
    {
        public string? SupplierName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}

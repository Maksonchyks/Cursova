using Cursova.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cursova.ViewModels
{
    public class CustomerViewModel
    {
        public string? CustomerName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }

    }
}

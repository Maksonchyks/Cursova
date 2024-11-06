using Microsoft.AspNetCore.Mvc;
using Cursova.Domain.Repositories.Abstract;
using Cursova.Models;
using Cursova.ViewModels;

namespace Cursova.Controllers
{
    public class SelectDataController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IStockService _stockService;
        private readonly ISupplierService _supplierService;

        public SelectDataController
        (
            ICustomerService customerService,
            IStockService stockService,
            ISupplierService supplierService
        )
        {
            _customerService = customerService;
            _stockService = stockService;
            _supplierService = supplierService;
        }
        public IActionResult CustomerFilter(CustomerViewModel filter)
        {
            var customers = _customerService.GetCustomers(filter);
            ViewBag.Customers = customers;
            return View();
        }
        public IActionResult StockFilter(StockViewModel filter)
        {
            var stocks = _stockService.GetStock(filter);
            ViewBag.Stocks = stocks;
            return View();
        }
        public IActionResult SupplierFilter(SupplierViewModel filter)
        {
            var supplier = _supplierService.GetSupplier(filter);
            ViewBag.Suppliers = supplier;
            return View();
        }

        [HttpPost]
        public IActionResult SelectEntity(string entity)
        {
            switch (entity)
            {
                case "Customer":
                    return RedirectToAction("CustomerFilter");
                case "Supplier":
                    return RedirectToAction("SupplierFilter");
                case "Stock":
                    return RedirectToAction("StockFilter");
                default:
                    return RedirectToAction("Index");
            }
        }

        public IActionResult SelectIndex() 
        {
            return View();
        }
    }
}

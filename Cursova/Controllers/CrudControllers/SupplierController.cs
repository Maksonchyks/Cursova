using Cursova.Models;
using Microsoft.AspNetCore.Mvc;
using Cursova.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Cursova.Controllers.CrudControllers
{
    [Authorize(Roles = "Owner,Admin,Operator")]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supllierService;
        private readonly AppDbContext _context;

        public SupplierController(ISupplierService supplierService, AppDbContext context)
        {
            _supllierService = supplierService;
            _context=context;
        }
        public IActionResult SupplierIndex()
        {
            ViewData["Stocks"] = _context.Stocks.ToList();
            ViewData["Suppliers"] = _context.Suppliers.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _supllierService.AddSupplier(supplier);
            }
            else
            {
                Console.WriteLine("error");
            }
            return RedirectToAction("CrudIndex", "Crud");
        }
        [HttpPost]
        public IActionResult Update(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _supllierService.UpdateSupplier(supplier);
            }
            return RedirectToAction("CrudIndex", "Crud");

        }
        [HttpPost]
        public IActionResult Delete(int SupplierId)
        {
            if (ModelState.IsValid)
            {
                _supllierService.DeleteSupplier(SupplierId);
            }
            return RedirectToAction("CrudIndex", "Crud");
        }
    }
}

using Cursova.Models;
using Microsoft.AspNetCore.Mvc;
using Cursova.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;

namespace Cursova.Controllers.CrudControllers
{
    [Authorize]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supllierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supllierService = supplierService;
        }
        public IActionResult SupplierIndex()
        {
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

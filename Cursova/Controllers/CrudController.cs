using Microsoft.AspNetCore.Mvc;

namespace Cursova.Controllers
{
    public class CrudController : Controller
    {
        [HttpPost]
        public IActionResult EntitySelecton(string entityType)
        {
            if (string.IsNullOrEmpty(entityType))
            {
                return BadRequest("Entity type is required.");
            }

            switch (entityType.ToLower())
            {
                case "customer":
                    return RedirectToAction( "CustomerIndex", "Customer");
                case "supplier":
                    return RedirectToAction("SupplierIndex", "Supplier");
                case "stock":
                    return RedirectToAction("StockIndex", "Stock");
                case "salesdeal":
                    return RedirectToAction("SalesDealIndex", "SalesDeal");
                default:
                    return BadRequest("Invalid entity type.");
            }
        }
        public IActionResult CrudIndex()
        {
            return View();
        }
    }
}

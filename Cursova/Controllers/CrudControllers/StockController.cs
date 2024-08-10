using Cursova.Domain.Repositories.Abstract;
using Cursova.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cursova.Controllers.CrudControllers
{
    public class StockController : Controller
    {
        private readonly IStockService _stockService;
        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }
        public IActionResult StockIndex()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Stock stock)
        {
            if (ModelState.IsValid)
            {
                _stockService.AddStock(stock);
            }
            return RedirectToAction("CrudIndex", "Crud");

        }
        [HttpPost]
        public IActionResult Update(Stock stock)
        {
            if (ModelState.IsValid)
            {
                _stockService.UpdateStock(stock);
            }
            return RedirectToAction("CrudIndex", "Crud");

        }
        [HttpPost]
        public IActionResult Delete(int StockId)
        {
            if (ModelState.IsValid)
            {
                _stockService.DeleteStock(StockId);
            }
            return RedirectToAction("CrudIndex", "Crud");
        }
    }
}

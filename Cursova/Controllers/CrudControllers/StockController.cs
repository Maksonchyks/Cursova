using Cursova.Domain.Repositories.Abstract;
using Cursova.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cursova.Controllers.CrudControllers
{
    [Authorize(Roles = "Owner,Admin,Operator")]
    public class StockController : Controller
    {
        private readonly IStockService _stockService;
        private readonly AppDbContext _context;
        public StockController
        (
            IStockService stockService, 
            AppDbContext context
        )
        {
            _stockService = stockService;
            _context=context;
        }
        public IActionResult StockIndex()
        {
            ViewData["Stocks"] = _context.Stocks.ToList();
            ViewData["Suppliers"] = _context.Suppliers.ToList();
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

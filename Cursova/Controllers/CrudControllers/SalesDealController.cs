using Cursova.Domain.Repositories.Abstract;
using Cursova.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cursova.Controllers.CrudControllers
{
    [Authorize]
    public class SalesDealController : Controller
    {
        private readonly ISalesDealService _salesDealService;
        private readonly AppDbContext _context;
        public SalesDealController(ISalesDealService salesDealService, AppDbContext context)
        {
            _salesDealService = salesDealService;
            _context = context;
        }
        public IActionResult SalesDealIndex()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(SalesDeal salesDeal)
        {
            if (ModelState.IsValid)
            {
                var stock = _context.Stocks.Find(salesDeal.FrStockId);
                if (stock != null)
                {
                    salesDeal.TotalAmount = salesDeal.QuantitySold * stock.SalePrice;
                    _salesDealService.AddSalesDeal(salesDeal);

                }
            }
            return RedirectToAction("CrudIndex", "Crud");

        }
        [HttpPost]
        public IActionResult Update(SalesDeal salesDeal)
        {
            if (ModelState.IsValid)
            {
                _salesDealService.UpdateSalesDeal(salesDeal);
            }
            return RedirectToAction("CrudIndex", "Crud");

        }
        [HttpPost]
        public IActionResult Delete(int DealId)
        {
            if (ModelState.IsValid)
            {
                _salesDealService.DeleteSalesDeal(DealId);
            }
            return RedirectToAction("CrudIndex", "Crud");
        }
    }
}

using Cursova.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cursova.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private readonly AppDbContext _context;
        public RoleController(AppDbContext context) 
        {
            _context = context;
        }
        [Authorize(Roles = "Owner,Admin")]
        public IActionResult RoleOperation()
        {
            return RedirectToAction("AccessIndex", "AccessRole");
        }

        [Authorize(Roles = "Owner,Admin")]
        public IActionResult TableOperation()
        {
            return RedirectToAction("SelectIndex", "SelectData");
        }

        [Authorize(Roles = "Owner,Admin,Operator")]
        public IActionResult CrudOperation()
        {
            return RedirectToAction("CrudIndex", "Crud");
        }

        [Authorize(Roles = "Owner,Admin,Operator,User")]
        public IActionResult CheckData()
        {
            ViewData["Customers"] = _context.Customers.ToList();
            ViewData["SalesDeals"] = _context.SalesDeals.ToList();
            ViewData["Stocks"] = _context.Stocks.ToList();
            ViewData["Suppliers"] = _context.Suppliers.ToList();
            return View();
        }

        public IActionResult RoleIndex()
        {
            return View();
        }

    }
}

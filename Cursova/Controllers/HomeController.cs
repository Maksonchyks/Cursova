using Cursova.Models;
//using Cursova.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cursova.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
			return View();
        }
        public IActionResult Login()
        {
            return RedirectToAction("Login", "Auth");
        }
        public IActionResult Register()
        {
			return RedirectToAction("Register", "Auth");
        }
    }
}
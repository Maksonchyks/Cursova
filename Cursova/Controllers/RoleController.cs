using Cursova.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cursova.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RoleOperation()
        {
            return View();
        }
        public IActionResult TableOperation()
        {
            return View();
        }
        public IActionResult CrudOperation()
        {
            return View();
        }
        public IActionResult ViewData()
        {
            return View();
        }
    }
}

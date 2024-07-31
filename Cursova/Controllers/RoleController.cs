using Cursova.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cursova.Controllers
{
    public class RoleController : Controller
    {
        [Authorize(Roles = "Owner,Admin")]
        public IActionResult RoleOperation()
        {
            return View();
        }

        [Authorize(Roles = "Owner,Admin")]
        public IActionResult TableOperation()
        {
            return View();
        }

        [Authorize(Roles = "Owner,Admin,Operator")]
        public IActionResult CrudOperation()
        {
            return View();
        }

        [Authorize]
        public IActionResult CheckData()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}

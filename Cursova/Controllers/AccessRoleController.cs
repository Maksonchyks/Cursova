using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cursova.ViewModels;

namespace Cursova.Controllers
{
    [Authorize]
    public class AccessRoleController : Controller
    {
        private readonly AppDbContext _context;
        public AccessRoleController(AppDbContext context)
        {
            _context=context;
        }
        [Authorize(Roles = "Owner,Admin")]
        [HttpPost]
        public IActionResult SetUserRole(UserRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userContext = _context.Users.FirstOrDefault(u => u.Email == model.Email);
                if (userContext != null)
                {
                    if (User.IsInRole("Owner"))
                    {
                        userContext.Role = model.Role;
                    }
                    else if (User.IsInRole("Admin"))
                    {
                        if (userContext.Role == "Owner")
                        {
                            ModelState.AddModelError("", "Admin cannot change the role of the Owner.");
                            return RedirectToAction("Index", "Home");
                        }

                        if (model.Role == "Operator" || model.Role == "User")
                        {
                            userContext.Role = model.Role;
                        }
                        else
                        {
                            ModelState.AddModelError("", "Admin can only assign Operator or User roles.");
                            return View(model);
                        }
                    }
                    _context.SaveChanges();
                    return RedirectToAction("RoleIndex", "Role");
                }
                ModelState.AddModelError("", "User not found.");
            }
            return View(model);
        }

        [Authorize(Roles = "Owner,Admin")]
        public IActionResult AccessIndex()
        {
            return View();
        }
    }
}

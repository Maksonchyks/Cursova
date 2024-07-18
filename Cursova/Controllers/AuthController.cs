using Cursova.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cursova.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;
        public AuthController(AppDbContext context) 
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        // POST: /auth/login
        [HttpPost]
        public IActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    var role = user.Role.ToString().ToLower();
                    return RedirectToAction("Index", "Role"); // Приклад перенаправлення на домашню сторінку залежно від ролі
                }
                ModelState.AddModelError(string.Empty, "Неправильний емейл або пароль.");
            }
            return View(model);
        }

        // GET: /auth/register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /auth/register
        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.Users.FirstOrDefault(u => u.Email == model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "Цей емейл вже зайнятий.");
                }
                else
                {
                    var newUser = new User
                    {
                        Email = model.Email,
                        Password = model.Password,
                        Role = UserRole.User // Початкова роль може бути встановлена як UserRole.User або інша за вашим вибором
                    };
                    _context.Users.Add(newUser);
                    _context.SaveChanges();

                    return RedirectToAction("Login");
                }
            }
            return View(model);
        }
    }
}

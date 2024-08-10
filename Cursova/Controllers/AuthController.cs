using Cursova.Models;
using Cursova.Service;
using Microsoft.AspNetCore.Mvc;

namespace Cursova.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;
        private readonly JWTService _jwtService;

        public AuthController(AppDbContext context, JWTService jwtService) 
        {
            _context = context;
            _jwtService = jwtService;
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
                    var token = _jwtService.GenerateToken(user.Email, user.Role.ToString());
                    HttpContext.Response.Cookies.Append("JwtToken", token, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        Expires = DateTimeOffset.UtcNow.AddMinutes(5)
                    });
                    return RedirectToAction("RoleIndex", "Role"); 
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
                        Role = UserRole.User.ToString()
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

using IFATC_PROYECT.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace IFATC_PROYECT.Controllers
{
    public class AccountController : Controller
    {
        private readonly BD _database;

        public AccountController(BD database)
        {
            _database = database;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if the email is already registered
                var existingUser = _database.GetAllUsers().FirstOrDefault(u => u.Email == model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError(string.Empty, "Email is already registered.");
                    return View(model);
                }

                var user = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    UserRole = model.UserRole
                };

                // Hash the password
               var passwordHasher = new PasswordHasher<User>();
                user.PasswordHash = passwordHasher.HashPassword(user, model.Password);
                _database.AddUser(user);  // Add the user to the database
                return RedirectToAction("Login", "Account");
            }
            return View(model);  // If the model state is invalid, stay on the register page
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

       [HttpPost][HttpPost]
public async Task<IActionResult> Login(LoginViewModel model)
{
    if (!ModelState.IsValid)
    {
        ModelState.AddModelError(string.Empty, "Invalid input. Please try again.");
        return View(model);
    }

    var user = _database.GetAllUsers().FirstOrDefault(u => u.Email == model.Email);
    if (user != null)
    {
        var passwordHasher = new PasswordHasher<User>();
        var verificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
        if (verificationResult == PasswordVerificationResult.Success)
        {
            var claims = new[] {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.UserRole)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Password verification failed.");
        }
    }
    else
    {
        ModelState.AddModelError(string.Empty, "User not found.");
    }
    return View(model);
}



        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
            return RedirectToAction("Login", "Account");
        }
    }
}

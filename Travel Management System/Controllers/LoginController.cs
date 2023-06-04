using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;
using Travel_Management_System.EF;
using Travel_Management_System.EF.Models;
using Travel_Management_System.Models;

namespace Travel_Management_System.Controllers
{
    public class LoginController : Controller
    {
        private readonly TravelDb _db;

        public LoginController(TravelDb db)
        {
            _db = db;
        }

        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginPage(LoginModel obj)
        {
            if(ModelState.IsValid)
            {
                if (obj.Username == "admin" && obj.Password == "1234")
                {
                    List<Claim> claims = new List<Claim>()
                    { 
                        new Claim(ClaimTypes.NameIdentifier, obj.Username),
                        new Claim(ClaimTypes.Role, "Admin")
                    };

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    AuthenticationProperties properties = new AuthenticationProperties()
                    {
                        AllowRefresh = true,
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), properties);

                    return RedirectToAction("Dashboard", "Admin");
                }

                var traveler = (from u in _db.Users
                                where u.Username.Equals(obj.Username)
                                && u.Password.Equals(obj.Password)
                                select u).SingleOrDefault();

                if (traveler != null)
                {
                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, obj.Username),
                        new Claim(ClaimTypes.Role, "Traveler")
                    };

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    AuthenticationProperties properties = new AuthenticationProperties()
                    {
                        AllowRefresh = true
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), properties);

                    string TravelerJson = JsonSerializer.Serialize(traveler);
                    HttpContext.Session.SetString("Traveler", TravelerJson);

                    return RedirectToAction("Dashboard", "Traveler");
                }
                else
                {
                    ViewBag.Login = "Provide a valid Username or Password";
                    return View();
                }
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.Session.Remove("Traveler");

            //HttpContext.Session.Clear();

            return RedirectToAction("LoginPage");
        }
    }
}
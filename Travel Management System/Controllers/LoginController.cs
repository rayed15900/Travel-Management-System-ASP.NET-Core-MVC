using Microsoft.AspNetCore.Mvc;
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
        public IActionResult LoginPage(LoginModel obj)
        {
            if(ModelState.IsValid)
            {
                if (obj.Username == "admin" && obj.Password == "1234")
                {
                    var admin = (from a in _db.Users
                                 where a.Username.Equals("admin")
                                 select a).SingleOrDefault();

                    string AdminJson = JsonSerializer.Serialize(admin);
                    HttpContext.Session.SetString("Admin", AdminJson);

                    return RedirectToAction("Dashboard", "Admin");
                }

                var traveler = (from u in _db.Users
                                where u.Username.Equals(obj.Username)
                                && u.Password.Equals(obj.Password)
                                select u).SingleOrDefault();

                if (traveler != null)
                {
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

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginPage");
        }
    }
}

//string TravelerJsonFromSession = HttpContext.Session.GetString("Traveler");
//var TravelerFromSession = JsonSerializer.Deserialize<User>(TravelerJsonFromSession);

//return View(TravelerFromSession);
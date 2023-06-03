using Microsoft.AspNetCore.Mvc;
using Travel_Management_System.EF;
using Travel_Management_System.EF.Models;

namespace Travel_Management_System.Controllers
{
    public class RegisterController : Controller
    {
        private readonly TravelDb _db;

        public RegisterController(TravelDb db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult RegisterPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterPage(User obj)
        {
            obj.Role = "Traveler";
            ModelState.Remove("Role");

            if (ModelState.IsValid)
            {
                _db.Users.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("LoginPage", "Login");
            }
            return View();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Travel_Management_System.EF;
using Travel_Management_System.EF.Models;

namespace Travel_Management_System.Controllers
{
    [Authorize(Roles = "Traveler, Admin")]
    public class TravelerController : Controller
    {
		private readonly TravelDb _db;

		public TravelerController(TravelDb db)
		{
			_db = db;
		}

		public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Profile()
        {
			string TravelerJsonFromSession = HttpContext.Session.GetString("Traveler");
			var TravelerFromSession = JsonSerializer.Deserialize<User>(TravelerJsonFromSession);

			return View(TravelerFromSession);
        }

		
		public IActionResult ProfileEdit(int id)
		{
			var profile = (from x in _db.Users
						   where x.Id == id
						   select x).SingleOrDefault();

			return View(profile);
		}

		[HttpPost]
		public IActionResult ProfileEdit(User obj)
		{
			if(ModelState.IsValid)
			{
				_db.Users.Update(obj);

				_db.SaveChanges();

				return RedirectToAction("Profile");
			}
			return View();
		}
	}
}

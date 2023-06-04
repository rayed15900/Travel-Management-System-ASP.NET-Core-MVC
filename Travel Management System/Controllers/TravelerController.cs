using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Travel_Management_System.Controllers
{
    [Authorize(Roles = "Traveler, Admin")]
    public class TravelerController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}

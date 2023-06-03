using Microsoft.AspNetCore.Mvc;

namespace Travel_Management_System.Controllers
{
    public class TravelerController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}

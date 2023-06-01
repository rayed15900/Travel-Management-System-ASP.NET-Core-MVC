using Microsoft.AspNetCore.Mvc;

namespace Travel_Management_System.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

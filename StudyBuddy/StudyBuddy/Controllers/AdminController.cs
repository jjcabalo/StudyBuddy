using Microsoft.AspNetCore.Mvc;

namespace StudyBuddy.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

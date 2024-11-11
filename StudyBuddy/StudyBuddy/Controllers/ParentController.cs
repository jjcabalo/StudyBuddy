using Microsoft.AspNetCore.Mvc;

namespace StudyBuddy.Controllers
{
    public class ParentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

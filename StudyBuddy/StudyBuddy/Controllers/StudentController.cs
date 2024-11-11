using Microsoft.AspNetCore.Mvc;

namespace StudyBuddy.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

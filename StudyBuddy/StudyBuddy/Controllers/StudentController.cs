using Microsoft.AspNetCore.Mvc;

namespace StudyBuddy.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult StudentHome()
        {
            return View();
        }

        public IActionResult Trash() {
            return View();
        }
    }
}

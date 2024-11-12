using Microsoft.AspNetCore.Mvc;

namespace StudyBuddy.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult StudentsHome()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace StudyBuddy.Controllers
{
    public class ParentController : Controller
    {
        public IActionResult StudentManagement()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace StudyBuddy.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult ManageAccounts()
        {
            return View();
        }

        public IActionResult ParStuLinking() {
            return View();
        }
    }
}

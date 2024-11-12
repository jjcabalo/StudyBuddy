using Microsoft.AspNetCore.Mvc;

namespace StudyBuddy.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}

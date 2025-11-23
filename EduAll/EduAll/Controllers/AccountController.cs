using Microsoft.AspNetCore.Mvc;

namespace EduAll.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Signin()
        {
            return View();
        }
    }
}

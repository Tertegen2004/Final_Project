using Microsoft.AspNetCore.Mvc;

namespace EduAll.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

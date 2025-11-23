using Microsoft.AspNetCore.Mvc;

namespace EduAll.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace EduAll.Controllers
{
    public class LessonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

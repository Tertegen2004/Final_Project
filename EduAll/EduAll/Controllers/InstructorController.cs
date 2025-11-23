using Microsoft.AspNetCore.Mvc;

namespace EduAll.Controllers
{
    public class InstructorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            return View();
        }
    }
}

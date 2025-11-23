using Microsoft.AspNetCore.Mvc;

namespace EduAll.Controllers
{
    public class FavoriteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

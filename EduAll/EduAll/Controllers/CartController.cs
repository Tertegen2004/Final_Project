using Microsoft.AspNetCore.Mvc;

namespace EduAll.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

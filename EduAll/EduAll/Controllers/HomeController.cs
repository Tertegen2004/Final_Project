using EduAll.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduAll.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUniteOfWork unite;

        public IActionResult Index()
        {
            return View();
        }
    }
}

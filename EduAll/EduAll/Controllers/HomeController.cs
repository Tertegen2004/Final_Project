using EduAll.Domain;
using EduAll.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EduAll.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUniteOfWork _uniteOfWork;

        public HomeController(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }

        // Home + فلترة بالكاتجوري
        public async Task<IActionResult> Index(int? categoryId)
        {
            // الكاتجوري مع الكورسات (لو محتاج العدادات)
            var catQuery = _uniteOfWork.Category.GettAll(null, c => c.Courses);
            var categories = catQuery.ToList();

            // نبعته للـLayout عشان الدروب ليست اللي في السيرش بار
            ViewBag.AllCategories = categories;

            // الكورسات للسيكشن Popular Courses
            var courseQuery =_uniteOfWork.Course.GettAll();

            if (categoryId.HasValue)
            {
                courseQuery = courseQuery.Where(c => c.CategoryId == categoryId.Value);
            }

            // نعرض 6 كورسات بس في الهوم
            var homeCourses = courseQuery.Take(6).ToList();

            ViewBag.SelectedCategoryId = categoryId;
            ViewBag.HomeCourses = homeCourses;

            // الموديل الأساسي للصفحة هو قائمة الكاتجوري
            return View(categories);
        }
    }
}

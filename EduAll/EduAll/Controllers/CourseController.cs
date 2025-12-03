using EduAll.Domain;
using Microsoft.AspNetCore.Mvc;
using EduAll.Repository;

namespace EduAll.Controllers
{
    public class CourseController : Controller
    {
        private readonly IUniteOfWork _unitOfWork;

        public CourseController(IUniteOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /Course
        public async Task<IActionResult> Index(int? categoryId)
        {
            // الكورسات
            var query =_unitOfWork.Course.GettAll();

            if (categoryId.HasValue)
                query = query.Where(c => c.CategoryId == categoryId.Value);

            var courses = query.ToList();

            // الكاتيجوري للـselect (صفحة الكورسات)
            var catQuery =_unitOfWork.Category.GettAll();
            ViewBag.Categories = catQuery.ToList();

            // نفس الكاتيجوري هتستخدم في السيرش بار في اللAYOUT
            ViewBag.AllCategories = ViewBag.Categories;

            return View(courses);   // الموديل: IEnumerable<Course>
        }

        // GET: /Course/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var course =await _unitOfWork.Course.FindById(id);

            if (course == null)
                return NotFound();

            return View(course);
        }

        // GET: /Course/Search?term=...&categoryId=...
        public async Task<IActionResult> Search(string? term, int? categoryId)
        {
            var query =_unitOfWork.Course.GettAll(null, c => c.Category);

            if (categoryId.HasValue)
                query = query.Where(c => c.CategoryId == categoryId.Value);

            if (!string.IsNullOrWhiteSpace(term))
                query = query.Where(c => c.Title.Contains(term));

            var results = query.ToList();

            var catQuery = _unitOfWork.Category.GettAll();
            ViewBag.Categories = catQuery.ToList();
            ViewBag.AllCategories = ViewBag.Categories;
            ViewBag.SelectedCategoryId = categoryId;
            ViewBag.SearchTerm = term;

            return View("SearchResults", results);   // View جديدة لنتائج البحث
        }

        // GET: /Course/Suggest?term=...&categoryId=...
        [HttpGet]
        public async Task<IActionResult> Suggest(string term, int? categoryId)
        {
            if (string.IsNullOrWhiteSpace(term))
                return Json(Enumerable.Empty<string>());

            var query = _unitOfWork.Course.GettAll();

            if (categoryId.HasValue)
                query = query.Where(c => c.CategoryId == categoryId.Value);

            var titles = query
                .Where(c => c.Title.Contains(term))
                .OrderBy(c => c.Title)
                .Select(c => c.Title)
                .Distinct()
                .Take(6)
                .ToList();

            return Json(titles);
        }
    }
}

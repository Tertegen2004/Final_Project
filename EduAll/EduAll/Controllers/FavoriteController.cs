using EduAll.Domain;
using EduAll.Repository;
using Microsoft.AspNetCore.Mvc;

public class FavoriteController : Controller
{
    private readonly IUniteOfWork _unitOfWork;
    private const string GuestUserId = "guest";

    public FavoriteController(IUniteOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        var items = _unitOfWork.Wishlist
                               .GettAll(x => x.UserId == GuestUserId, x => x.Course)
                               .ToList();
        return View(items);
    }

    [HttpPost]
    public IActionResult Add(int courseId)
    {
        var exists = _unitOfWork.Wishlist
                                .GettAll(x => x.UserId == GuestUserId && x.CourseId == courseId)
                                .Any();

        if (!exists)
        {
            _unitOfWork.Wishlist.Create(new Wishlist
            {
                UserId = GuestUserId,
                CourseId = courseId
            });
        }

        var count = _unitOfWork.Wishlist
                               .GettAll(x => x.UserId == GuestUserId)
                               .Count();

        return Json(new { success = true, count });
    }

    [HttpPost]
    public IActionResult Remove(int courseId)
    {
        var repo = _unitOfWork.Wishlist;
        var item = repo.GettAll(x => x.UserId == GuestUserId && x.CourseId == courseId)
                       .FirstOrDefault();

        if (item != null)
        {
            repo.Delete(item.Id);
        }

        var count = repo.GettAll(x => x.UserId == GuestUserId).Count();
        return Json(new { success = true, count });
    }

    [HttpPost]
    public IActionResult RemoveAll()
    {
        var repo = _unitOfWork.Wishlist;
        var allItems = repo.GettAll(x => x.UserId == GuestUserId).ToList();

        if (allItems.Any())
        {
            repo.DeleteAll(allItems);
        }

        return Json(new { success = true, count = 0 });
    }

    [HttpGet]
    public IActionResult Count()
    {
        var count = _unitOfWork.Wishlist
                               .GettAll(x => x.UserId == GuestUserId)
                               .Count();
        return Json(new { count });
    }
}

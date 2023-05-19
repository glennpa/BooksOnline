using BooksOnlineWeb.Data;
using BooksOnline.Models;
using Microsoft.AspNetCore.Mvc;
using BooksOnline.DataAccess.Repository.IRepository;

namespace BooksOnlineWeb.Areas.Admin.Controllers;
[Area("Admin")]

public class CategoryController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    //List or Browse
    public IActionResult Index()
    {
        IEnumerable<Category> ObjCategoryList = _unitOfWork.Category.GetAll();
        return View(ObjCategoryList);
    }

    // GET Create Record
    public IActionResult Create()
    {
        return View();
    }

    // POST Create Record
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder cannot be exactly match the Name.");
        }
        if (ModelState.IsValid)
        {
            _unitOfWork.Category.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    // GET Edit
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        //var categoryFromDb = _db.Categories.Find(id);
        var categoryFromFirst = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
        //var categoryFromSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
        if (categoryFromFirst == null)
        {
            return NotFound();
        }
        return View(categoryFromFirst);
    }

    // POST Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder cannot be exactly match the Name.");
        }
        if (ModelState.IsValid)
        {
            _unitOfWork.Category.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    // GET Delete
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        //var categoryFromDb = _db.Categories.Find(id);
        var categoryFromFirst = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
        //var categoryFromSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
        if (categoryFromFirst == null)
        {
            return NotFound();
        }
        return View(categoryFromFirst);
    }

    // POST Delete
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return NotFound();
        }
        _unitOfWork.Category.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");
    }
}

using BooksOnlineWeb.Data;
using BooksOnline.Models;
using Microsoft.AspNetCore.Mvc;
using BooksOnline.DataAccess.Repository.IRepository;

namespace BooksOnlineWeb.Areas.Admin.Controllers;
[Area("Admin")]

public class CoverTypeController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CoverTypeController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    //List or Browse
    public IActionResult Index()
    {
        IEnumerable<CoverType> ObjCoverTypeList = _unitOfWork.CoverType.GetAll();
        return View(ObjCoverTypeList);
    }

    // GET Create Record
    public IActionResult Create()
    {
        return View();
    }

    // POST Create Record
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CoverType obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.CoverType.Add(obj);
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
        var coverTypeFromFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
        //var categoryFromSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
        if (coverTypeFromFirst == null)
        {
            return NotFound();
        }
        return View(coverTypeFromFirst);
    }

    // POST Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CoverType obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.CoverType.Update(obj);
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
        var coverTypeFromFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
        //var categoryFromSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
        if (coverTypeFromFirst == null)
        {
            return NotFound();
        }
        return View(coverTypeFromFirst);
    }

    // POST Delete
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return NotFound();
        }
        _unitOfWork.CoverType.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");
    }
}

using Microsoft.AspNetCore.Mvc;
using ZayProject.Data;
using ZayProject.Entities;

namespace ZayProject.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController : Controller
{
    private readonly AppDbContext _context;

    public CategoryController(AppDbContext context)
    {
        _context = context;
    }

    #region List

    public IActionResult Index()
    {
        var categories = _context.Categories.ToList();
        return View(categories);
    }

    #endregion

    #region Create

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category model)
    {
        if (!ModelState.IsValid) return View(model);

        _context.Categories.Add(model);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Update

    [HttpGet]
    public IActionResult Update(int id)
    {
        var category = _context.Categories.Find(id);
        if (category is null) return NotFound();

        return View(category);
    }

    [HttpPost]
    public IActionResult Update(int id, Category model)
    {
        if (!ModelState.IsValid) return View(model);

        var category = _context.Categories.Find(id);
        if (category is null) return NotFound();

        category.Name = model.Name;
        _context.Categories.Update(category);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Delete

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var category = _context.Categories.Find(id);
        if (category is null) return NotFound();

        _context.Categories.Remove(category);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    #endregion
}
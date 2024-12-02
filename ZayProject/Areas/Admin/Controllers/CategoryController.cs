using Microsoft.AspNetCore.Mvc;
using ZayProject.Areas.Admin.Models.Category;
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
        var model = new CategoryIndexVM
        {
            Categories = categories
        };
        
        return View(model);
    }   

    #endregion

    #region Create

    [HttpGet]
    public IActionResult Create()
    {
        var model = new CategoryCreateVM();
        return View(model);
    }

    [HttpPost]
    public IActionResult Create(CategoryCreateVM model)
    {
        if (!ModelState.IsValid) return View(model);
        
        var category = new Category
        {
            Name = model.Name
        };

        _context.Categories.Add(category);
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
        
        var model = new CategoryUpdateVM
        {
            Id = category.Id,
            Name = category.Name
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Update(int id, CategoryUpdateVM model)
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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZayProject.Data;
using ZayProject.Entities;

namespace ZayProject.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController : Controller
{
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context;
    }

    #region List

    public IActionResult Index()
    {
        var products = _context.Products.Include(p => p.Category).ToList();
        return View(products);
    }

    #endregion

    #region Create

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = _context.Categories.Select(c => new SelectListItem
        {
            Text = c.Name,
            Value = c.Id.ToString()
        }).ToList();

        return View();
    }

    [HttpPost]
    public IActionResult Create(Product model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = _context.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();
            return View(model);
        }

        _context.Products.Add(model);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Update

    [HttpGet]
    public IActionResult Update(int id)
    {
        var product = _context.Products.Find(id);
        if (product is null) return NotFound();

        ViewBag.Categories = _context.Categories.Select(c => new SelectListItem
        {
            Text = c.Name,
            Value = c.Id.ToString()
        }).ToList();

        return View(product);
    }

    [HttpPost]
    public IActionResult Update(int id, Product model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = _context.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();
            return View(model);
        }

        var product = _context.Products.Find(id);
        if (product is null) return NotFound();

        product.Name = model.Name;
        product.Price = model.Price;
        product.SizeOptions = model.SizeOptions;
        product.PhotoPath = model.PhotoPath;
        product.CategoryId = model.CategoryId;
        product.UpdatedAt = DateTime.Now;

        _context.Products.Update(product);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Delete

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var product = _context.Products.Find(id);
        if (product is null) return NotFound();

        _context.Products.Remove(product);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    #endregion
}

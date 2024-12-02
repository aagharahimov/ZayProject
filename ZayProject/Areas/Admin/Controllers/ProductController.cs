using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZayProject.Areas.Admin.Models.Product;
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
        var model = new ProductIndexVM()
        {
            Products = products
        };
        return View(model);
    }

    #endregion

    #region Create

    [HttpGet]
    public IActionResult Create()
    {
        var model = new ProductCreateVM();
        ViewBag.Categories = _context.Categories.Select(c => new SelectListItem
        {
            Text = c.Name,
            Value = c.Id.ToString()
        }).ToList();

        return View(model);
    }

    [HttpPost]
    public IActionResult Create(ProductCreateVM model)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("CategoryId", "The selected category is invalid.");
            ViewBag.Categories = _context.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();
            return View(model);
        }
        
        var product = new Product
        {
            Name = model.Name,
            Price = model.Price,
            SizeOptions = model.SizeOptions,
            PhotoPath = model.PhotoPath,
            CategoryId = model.CategoryId, 
            AverageRating = (decimal)model.AverageRating,
        };

        _context.Products.Add(product);
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
        
        var model = new ProductUpdateVM()
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            SizeOptions = product.SizeOptions,
            PhotoPath = product.PhotoPath,
            CategoryId = product.CategoryId
        };

        ViewBag.Categories = _context.Categories.Select(c => new SelectListItem
        {
            Text = c.Name,
            Value = c.Id.ToString()
        }).ToList();

        return View(model);
    }

    [HttpPost]
    public IActionResult Update(int id, ProductUpdateVM model)
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

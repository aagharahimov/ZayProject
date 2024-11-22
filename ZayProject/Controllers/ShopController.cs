using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZayProject.Data;
using ZayProject.Models.Shop;

namespace ZayProject.Controllers;

public class ShopController : Controller
{
    private readonly AppDbContext _context;

    public ShopController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(int? categoryId)
    {
        var categories = _context.Categories.Select(c => new CategoryVM
        {
            Id = c.Id,
            Name = c.Name
        }).ToList();

        var productsQuery = _context.Products.AsQueryable();

        if (categoryId.HasValue)
        {
            productsQuery = productsQuery.Where(p => p.CategoryId == categoryId.Value);
        }

        var products = productsQuery.Select(p => new ProductVM
        {
            Name = p.Name,
            Price = p.Price,
            PhotoPath = p.PhotoPath,
            SizeOptions = p.SizeOptions,
            AverageRating = p.AverageRating
        }).ToList();

        var model = new ShopIndexVM
        {
            Categories = categories,
            Products = products,
            SelectedCategoryId = categoryId
        };

        return View(model);
    }
}
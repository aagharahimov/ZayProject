using Microsoft.AspNetCore.Mvc;
using ZayProject.Data;
using ZayProject.Entities;

namespace ZayProject.Areas.Admin.Controllers;

[Area("Admin")]
public class SliderController : Controller
{
    private readonly AppDbContext _context;

    public SliderController(AppDbContext context)
    {
        _context = context;
    }

    #region List

    public IActionResult Index()
    {
        var sliders = _context.Sliders.ToList();
        return View(sliders);
    }

    #endregion

    #region Create

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Slider model)
    {
        if (!ModelState.IsValid) return View(model);

        model.CreatedAt = DateTime.Now;
        _context.Sliders.Add(model);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Update

    [HttpGet]
    public IActionResult Update(int id)
    {
        var slider = _context.Sliders.Find(id);
        if (slider is null) return NotFound();

        return View(slider);
    }

    [HttpPost]
    public IActionResult Update(int id, Slider model)
    {
        if (!ModelState.IsValid) return View(model);

        var slider = _context.Sliders.Find(id);
        if (slider is null) return NotFound();

        slider.Header1 = model.Header1;
        slider.Header2 = model.Header2;
        slider.Description = model.Description;
        slider.PhotoPath = model.PhotoPath;
        slider.ModifiedAt = DateTime.Now;

        _context.Sliders.Update(slider);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Delete

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var slider = _context.Sliders.Find(id);
        if (slider is null) return NotFound();

        _context.Sliders.Remove(slider);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    #endregion
}

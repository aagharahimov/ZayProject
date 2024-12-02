using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZayProject.Areas.Admin.Models.Slider;
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
        var model = new SliderIndexVM
        {
            Sliders = _context.Sliders.ToList()
        };
        
        return View(model);
    }

    #endregion
    
    #region Create

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(SliderCreateVM model)
    {
        if (!ModelState.IsValid) return View(model);

        var slider = new Slider()
        {
            Title = model.Title,
            SubTitle = model.SubTitle,
            Description = model.Description,
            PhotoPath = model.PhotoPath,
            CreatedAt = DateTime.Now,
            // UpdatedAt = DateTime.Now
        };

        _context.Sliders.Add(slider);
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

        var model = new SliderUpdateVM
        {
            Id = slider.Id,
            Title = slider.Title,
            SubTitle = slider.SubTitle,
            Description = slider.Description,
            PhotoPath = slider.PhotoPath
        };
        
        ViewBag.Sliders = _context.Sliders.Select(c => new SelectListItem
        {
            Text = c.Title,
            Value = c.Id.ToString()
        }).ToList();

        return View(model);
    }

    [HttpPost]
    public IActionResult Update(int id, SliderUpdateVM model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Sliders = _context.Sliders.Select(c => new SelectListItem
            {
                Text = c.Title,
                Value = c.Id.ToString()
            }).ToList();
            return View(model);
        }
        
        var slider = _context.Sliders.Find(id);
        if (slider is null) return NotFound();

        slider.Title = model.Title;
        slider.SubTitle = model.SubTitle;
        slider.Description = model.Description;
        slider.PhotoPath = model.PhotoPath;
        slider.UpdatedAt = DateTime.Now;

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

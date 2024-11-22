using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ZayProject.Models;
using ZayProject.Data;
using ZayProject.Areas.Admin.Models.Slider;
using ZayProject.Models.Home;

namespace ZayProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new SliderIndexVM
            {
                Sliders = _context.Sliders
                    .Select(s => new SliderVM
                    {
                        Id = s.Id,
                        Title = s.Title,
                        SubTitle = s.SubTitle,
                        Description = s.Description,
                        PhotoPath = s.PhotoPath,
                        CreatedAt = s.CreatedAt,
                        UpdatedAt = s.UpdatedAt
                    })
                    .ToList()
            };

            return View(model);
        }
    }
}

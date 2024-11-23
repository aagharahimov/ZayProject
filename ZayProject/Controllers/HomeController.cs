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
            var model = new HomeIndexVM()
            {
                Sliders = _context.Sliders.ToList()
            };

            return View(model);
        }
    }
}

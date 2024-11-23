using System.ComponentModel.DataAnnotations;
using ZayProject.Models.Home;
using ZayProject.Entities;
namespace ZayProject.Areas.Admin.Models.Slider;

public class SliderIndexVM
{
    public List<Entities.Slider> Sliders { get; set; }
}


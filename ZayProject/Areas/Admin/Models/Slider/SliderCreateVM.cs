using System.ComponentModel.DataAnnotations;
namespace ZayProject.Areas.Admin.Models.Slider;

public class SliderCreateVM
{
    [Required(ErrorMessage = "Title is required")]
    [MinLength(5, ErrorMessage = "Title must be at least 5 characters long.")]
    public string Title { get; set; }
    [Required(ErrorMessage = "SubTitle is required")]
    [MinLength(5, ErrorMessage = "SubTitle must be at least 5 characters long.")]
    public string SubTitle { get; set; }
    [Required(ErrorMessage = "Description is required")]
    [MinLength(10, ErrorMessage = "Description must be at least 10 characters long.")]
    public string Description { get; set; }
    public string PhotoPath { get; set; }
    public bool IsActive { get; set; }
}
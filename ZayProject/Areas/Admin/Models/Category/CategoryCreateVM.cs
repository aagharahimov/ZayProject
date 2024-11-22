using System.ComponentModel.DataAnnotations;
namespace ZayProject.Areas.Admin.Models.Category;

public class CategoryCreateVM
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
}
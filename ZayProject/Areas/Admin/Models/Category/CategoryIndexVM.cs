using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZayProject.Models.Shop;
namespace ZayProject.Areas.Admin.Models.Category;

public class CategoryIndexVM
{
    public List<CategoryVM> Categories { get; set; }
}
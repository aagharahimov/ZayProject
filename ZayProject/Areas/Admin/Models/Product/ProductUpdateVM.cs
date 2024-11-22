using System.ComponentModel.DataAnnotations;
namespace ZayProject.Areas.Admin.Models.Product;

public class ProductUpdateVM
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Price is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set; }

    public string SizeOptions { get; set; }
    public int CategoryId { get; set; }
    public string PhotoPath { get; set; }
}
using System.ComponentModel.DataAnnotations;
namespace ZayProject.Areas.Admin.Models.Product;
using ZayProject.Models.Shop;

public class ProductIndexVM
{
    public List<ProductVM> Products { get; set; }
}
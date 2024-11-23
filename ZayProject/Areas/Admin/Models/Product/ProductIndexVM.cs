using System.ComponentModel.DataAnnotations;
using ZayProject.Entities;
using ZayProject.Models.Shop;
namespace ZayProject.Areas.Admin.Models.Product;

public class ProductIndexVM
{
    public List<Entities.Product> Products { get; set; }
}
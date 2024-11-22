namespace ZayProject.Models.Shop;

public class ShopIndexVM
{
    public List<CategoryVM> Categories { get; set; }
    public List<ProductVM> Products { get; set; }
    public int? SelectedCategoryId { get; set; }
}
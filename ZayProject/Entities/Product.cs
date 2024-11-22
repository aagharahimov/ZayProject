namespace ZayProject.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string PhotoPath { get; set; } 
    public string SizeOptions { get; set; } 
    public decimal AverageRating { get; set; } 
    
    public int CategoryId { get; set; }
    
    public Category Category { get; set; }
}
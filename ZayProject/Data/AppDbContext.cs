using Microsoft.EntityFrameworkCore;
using ZayProject.Models;
using ZayProject.Entities;

namespace ZayProject.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Slider> Sliders { get; set; }
}

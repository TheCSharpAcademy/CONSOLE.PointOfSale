using KebPOS.Models;
using KebPOS.Services;
using Microsoft.EntityFrameworkCore;

namespace KebPOS.DbContexts;

internal class KebabContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Data source to be replaced with config connection string.
        //string projPath = Path.GetFullPath(@"..\..\..\");
        // optionsBuilder.UseSqlite($"Data Source=C:\\Pablo\\community\\CONSOLE.PointOfSale\\KebPOS\\Kebab.db;");
        optionsBuilder.UseSqlite($"Data Source=Kebab.db;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderProduct>()
            .HasKey(op => new { op.OrderId, op.ProductId });
        modelBuilder.Entity<OrderProduct>()
            .HasOne(op => op.Order)
            .WithMany(o => o.OrderProducts)
            .HasForeignKey(op => op.OrderId);
        modelBuilder.Entity<OrderProduct>()
            .HasOne(op => op.Product)
            .WithMany(p => p.OrderProducts)
            .HasForeignKey(op => op.ProductId);

        modelBuilder.Entity<Product>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<Product>()
            .HasIndex(p => p.Name)
            .IsUnique();

        modelBuilder.Entity<Product>()
            .HasData(ProductService.GetProducts());
    }
}

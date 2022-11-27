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
        optionsBuilder.UseSqlite("Data Source=KebabDb;");
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
            .HasData( ProductService.GetProducts());

        modelBuilder.Entity<Order>()
            .HasData(
            new Order
            {
                Id = 1,
                OrderDate = DateTime.UtcNow,
                TotalPrice = 11.81M
            },
             new Order
             {
                 Id = 2,
                 OrderDate = DateTime.UtcNow.AddMinutes(4),
                 TotalPrice = 6.86M
             },
             new Order
             {
                 Id = 3,
                 OrderDate = DateTime.UtcNow.AddMinutes(9),
                 TotalPrice = 7.75M
             });

        modelBuilder.Entity<OrderProduct>()
            .HasData(
            new OrderProduct
            {
                OrderId = 1,
                ProductId = 1,
            },
            new OrderProduct
            {
                OrderId = 1,
                ProductId = 5,
            },
            new OrderProduct
            {
                OrderId = 1,
                ProductId = 9,
            },
            new OrderProduct
            {
                OrderId = 2,
                ProductId = 1,
            },
            new OrderProduct
            {
                OrderId = 2,
                ProductId = 4,
            },
            new OrderProduct
            {
                OrderId = 3,
                ProductId = 6,
            },
            new OrderProduct
            {
                OrderId = 3,
                ProductId = 3,
            });

        
    }
}

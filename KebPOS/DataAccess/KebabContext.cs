using KebPOS.Models;
using Microsoft.EntityFrameworkCore;

namespace KebPOS.DataAccess;

internal class KebabContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Data source to be replaced with config connection string.
        optionsBuilder.UseSqlite("Data Source=KebabDb;");
    }
}

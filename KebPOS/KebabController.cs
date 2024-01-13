using KebPOS.DbContexts;
using KebPOS.Models;
using Microsoft.EntityFrameworkCore;

namespace KebPOS;

public class KebabController
{
    public void UpdateProductName(Product product, string newProductName)
    {
         using var db = new KebabContext();
        product.Name = newProductName;
        db.Entry(product).State = EntityState.Modified;
        db.SaveChanges();
    }

    public void UpdateProductPrice(Product product, decimal newPrice)
    {
        using var db = new KebabContext();
        product.Price = newPrice;
        db.Entry(product).State = EntityState.Modified;
        db.SaveChanges();
    }

    public void UpdateProductDescription(Product product, string newProductDescription)
    {
        using var db = new KebabContext();
        product.Description = newProductDescription;
        db.Entry(product).State = EntityState.Modified;
        db.SaveChanges();
    }
    public List<Product> GetProducts()
    {
        using var db = new KebabContext();
        return db.Products.OrderBy(x => x.Name).ToList();
    }

    public List<Order> GetOrders()
    {
        using var db = new KebabContext();
        return db.Orders.OrderBy(x => x.OrderDate).Include(o => o.OrderProducts).ThenInclude(p => p.Product).ToList();
    }

    public void AddOrders(List<OrderProduct> orderProductsList)
    {
        using var db = new KebabContext();

        db.OrderProducts.AddRange(orderProductsList);

        db.SaveChanges();
    }

    public void RemoveOrder(Order toBeRemoved)  // Burayi kodladın takip et: You coded here, follow
    {
        using var db = new KebabContext();
        db.Orders.Remove(toBeRemoved);
        db.SaveChanges();
    }

    internal static void AddProduct(Product product)
    {
        try
        {
            using var db = new KebabContext();
            db.Add(product);
            db.SaveChanges();
            Console.WriteLine("Product added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding product to the database: {ex.Message}");
        }
    }
}

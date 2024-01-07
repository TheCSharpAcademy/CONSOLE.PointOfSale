using KebPOS.DbContexts;
using KebPOS.Models;
using Microsoft.EntityFrameworkCore;

namespace KebPOS;

public class KebabController
{
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

    public void RemoveOrder(Order toBeRemoved)  // Burayi kodladın takip et
    {
        using var db = new KebabContext();
        db.Orders.Remove(toBeRemoved);
        db.SaveChanges();
    }
}

using KebPOS.DbContexts;
using KebPOS.Models;

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
        return db.Orders.OrderBy(x => x.OrderDate).ToList();
    }

    public void AddOrders(Order order/*, List<OrderProduct> orderProductsList*/)
    {
        using var db = new KebabContext();

        // db.OrderProducts.AddRange(orderProductsList);
        db.Orders.Add(order);

        db.SaveChanges();
    }
}

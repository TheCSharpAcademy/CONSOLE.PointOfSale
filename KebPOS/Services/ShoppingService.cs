namespace KebPOS.Services;

public class ShoppingService
{
    public void GetProducts()
    {
        var kebabController = new KebabController();
        var products = kebabController.GetProducts();
        foreach (var product in products)
        {
            Console.WriteLine(product.Id);
            Console.WriteLine(product.Name);
            Console.WriteLine(product.Description);
            Console.WriteLine(product.Price);
        }
    }

    public void GetOrders()
    {
        var kebabController = new KebabController();
        var orders = kebabController.GetOrders();
        foreach (var order in orders)
        {
            Console.WriteLine(order.Id);
            Console.WriteLine(order.OrderDate);
            Console.WriteLine(order.TotalPrice);
        }
    }
}
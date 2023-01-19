using KebPOS.Models;
using KebPOS.Services;

namespace KebPOS;

public class UserInput
{
    public string GetId()
    {
        var id = Console.ReadLine();
        while (!Validation.IsValidIdInput(id))
        {
            id = Console.ReadLine();
        }

        return id;
    }

    public static void CreateOrder()
    {
        Order order = new()
        {
            OrderDate = DateTime.Now,
        };
        var products = GetProductsForOrder(order);
        var orderProducts = new List<OrderProduct>();
        foreach (var product in products)
        {
            orderProducts.Add(new OrderProduct()
            {
                ProductId = product.Id
            });
        }
        order.TotalPrice = products.Sum(x => x.Price);
        order.OrderProducts = orderProducts;
        KebabController.AddOrder(order);
    }

    private static List<Product> GetProductsForOrder(Order order)
    {
        var products = new List<Product>();
        bool orderComplete = false;
        while (!orderComplete)
        {
            Console.WriteLine("Please enter a product ID or type 'done' to complete your order.");
            string input = Console.ReadLine();
            if (input == "done")
            {
                orderComplete = true;
            }
            else
            {
                while (!Validation.IsValidProductId(input))
                {
                    Console.WriteLine("Invalid Product ID: Please try again.");
                    input = Console.ReadLine();
                }
                var requestedProduct = ProductService.GetProducts().Where(x => x.Id == int.Parse(input)).FirstOrDefault();
                products.Add(requestedProduct);
            }
        }
        return products;
    }
}
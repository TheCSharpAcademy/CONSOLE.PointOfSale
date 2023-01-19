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
        GetProductsForOrder(order);
        order.TotalPrice = order.OrderProducts.Sum(x => x.Product.Price);
        KebabController.AddOrder(order);
    }

    private static void GetProductsForOrder(Order order)
    {
        List<OrderProduct> products = new List<OrderProduct>();
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
                OrderProduct orderProduct = GetOrderProduct(order, input);
                products.Add(orderProduct);
            }
        }
        order.OrderProducts = products;
    }

    private static OrderProduct GetOrderProduct(Order order, string input)
    {
        while (!Validation.IsValidProductId(input))
        {
            Console.WriteLine("Invalid Product ID: Please try again.");
            input = Console.ReadLine();
        }
        Product requestedProduct = ProductService.GetProducts().Where(x => x.Id == int.Parse(input)).FirstOrDefault();
        var orderProduct = new OrderProduct()
        {
            Order = order,
            ProductId = requestedProduct.Id,
            Product = requestedProduct,
        };
        return orderProduct;
    }
}
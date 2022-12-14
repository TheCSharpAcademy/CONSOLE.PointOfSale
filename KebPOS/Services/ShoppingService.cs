using KebPOS.Models;

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
}
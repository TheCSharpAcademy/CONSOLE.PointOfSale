using KebPOS.Models;

namespace KebPOS;

public class MainMenu
{
    private readonly KebabController _kebabController = new();
    private readonly UserInput _userInput = new();
    internal void InitializeMenu()
    {
        bool closeMenu = false;

        while (closeMenu == false)
        {
            Console.WriteLine("\nWelcome to KebPOS");
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("Type 1 to add new order");
            Console.WriteLine("Type 2 to view orders");
            Console.WriteLine("Type 3 to view order details");
            Console.WriteLine("\nType 0 to Close Application.");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    closeMenu = true;
                    break;
                case "1":
                    AddNewOrder();
                    break;
                case "2":
                    ViewOrders();
                    break;
                case "3":
                    ViewOrderDetails();
                    break;
                default:
                    Console.WriteLine("\nInvalid Command. Please type a number from 1 - 3.\n");
                    break;
            }
        }
    }

    private void AddNewOrder()
    {
        List<OrderProduct> orderProductsList = new();
        var order = new Order();
        decimal totalPrice = 0;

        string answer;
        do
        {
            var products = _kebabController.GetProducts();

            DisplayProducts(products);

            var selectedProduct = SelectProduct(products);

            var orderProduct = new OrderProduct
            {
                ProductId = selectedProduct!.Id
            };

            totalPrice += selectedProduct!.Price;

            orderProductsList.Add(orderProduct);

            Console.Write("Do you want to add another product to your order? yes/no: ");
            answer = _userInput.GetValidAnswer();
        } while (answer != "n" && answer != "no");

        // var order = new Order
        // {
        //     OrderDate = DateTime.Now,
        //     TotalPrice = totalPrice,
        // };

        _kebabController.AddOrders(order/*, orderProductsList*/);
    }

    private Product SelectProduct(List<Product> products)
    {
        Console.Write("Select a product by Id to add to cart: ");
        var choice = _userInput.GetId();

        var id = int.Parse(choice);

        while (!products.Exists(p => p.Id == id))
        {
            Console.Write("Select a product by Id to add to cart: ");
            choice = _userInput.GetId();

            id = int.Parse(choice);
        }


        var selectedProduct = products.First(p => p.Id == id);

        return selectedProduct;
    }

    private static void DisplayProducts(List<Product> products)
    {
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Id}\n{product.Name}\n{product.Description}\n{product.Price}\n\n");
        }
    }

    private void ViewOrders()
    {
        throw new NotImplementedException();
    }

    private void ViewOrderDetails()
    {
        throw new NotImplementedException();
    }
}

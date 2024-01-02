using KebPOS.Models;
using KebPOS.Models.Dtos;
using Microsoft.EntityFrameworkCore.Storage;
using Spectre.Console;
using static KebPOS.Models.Enums;

namespace KebPOS;

public class MainMenu
{
    private readonly KebabController _kebabController = new();
    private readonly UserInput _userInput = new();
    private readonly UserInterface _userInterface = new();

    internal void InitializeMenu()
    {
        bool closeMenu = false;

        while (closeMenu == false)
        {
            var selection = AnsiConsole.Prompt(
     new SelectionPrompt<MainMenuSelections>()
    .Title("Welcome to [green]KebPOS[/]\nWhat would you like to do?")
    .PageSize(10)
    .MoreChoicesText("")
    .AddChoices(MainMenuSelections.NewOrder,
    MainMenuSelections.ViewOrders,
    MainMenuSelections.ViewOrderDetails,
    MainMenuSelections.CloseApplication));

            switch (selection)
            {
                case MainMenuSelections.CloseApplication:
                    closeMenu = true;
                    break;
                case MainMenuSelections.NewOrder:
                    AddNewOrder();
                    break;
                case MainMenuSelections.ViewOrders:
                    ViewOrders(_kebabController.GetOrders());
                    break;
                case MainMenuSelections.ViewOrderDetails:
                    ViewOrderDetails();
                    break;
            }
        }
    }

    private void AddNewOrder()
    {
        Dictionary<int, int> productQuantityPairs = new();

        decimal totalPrice = 0;

        do
        {
            var products = _kebabController.GetProducts();

            var productDtoList = MapProductListToProductDtoList(products);

            _userInterface.DisplayProducts(productDtoList);

            var id = GetSelectedProduct(products);
            if (id == -1) // user canceled
            {
                Console.Clear();
                break;
            }

            var quantity = GetProductQuantity();

            if (quantity == -1) // user canceled
            {
                Console.Clear();
                break;
            }

            if (productQuantityPairs.ContainsKey(id))
            {
                productQuantityPairs[id] += quantity;
                totalPrice += GetPrice(id, products) * quantity;
            }
            else
            {
                productQuantityPairs[id] = quantity;
                totalPrice += GetPrice(id, products) * quantity;
            }
        } while (AnsiConsole.Confirm("Do you want to add another product to your order?"));

        var order = CreateNewOrder(totalPrice);

        var orderProductsList = GetOrderProductList(productQuantityPairs, order);

        _kebabController.AddOrders(orderProductsList);
    }

    private int GetProductQuantity()
    {
        Console.Write("How many do you want to add to your order? ('back' to cancel): ");
        var quantity = _userInput.GetQuantity();

        return quantity;
    }

    private Order CreateNewOrder(decimal totalPrice)
    {
        return new Order
        {
            OrderDate = DateTime.Now,
            TotalPrice = totalPrice,
        };
    }

    private List<OrderProduct> GetOrderProductList(Dictionary<int, int> productQuantityPairs, Order order)
    {
        List<OrderProduct> orderProductsList = new();

        foreach (var productId in productQuantityPairs.Keys)
        {
            var orderProduct = new OrderProduct
            {
                ProductId = productId,
                Order = order,
                Quantity = productQuantityPairs[productId]
            };

            orderProductsList.Add(orderProduct);
        }

        return orderProductsList;
    }

    private decimal GetPrice(int id, List<Product> products)
    {
        var price = products.First(p => p.Id == id).Price;

        return price;
    }

    private int GetSelectedProduct(List<Product> products)
    {
        Console.Write("Select a product by Id to add to cart ('back' to cancel): ");
        var id = _userInput.GetId();

        if (id == -1) // user canceled
        {
            return -1;
        }

        while (!products.Exists(p => p.Id == id))
        {
            Console.Write("Select a product by Id to add to cart ('back' to cancel): ");
            id = _userInput.GetId();
            if (id == -1) // user canceled
            {
                return -1;
            }
        }

        return id;
    }

    private void ViewOrders(List<Order> orders)
    {
        _userInterface.DisplayOrders(orders);
    }

    private void ViewOrderDetails()
    {
        List<Order> orders = _kebabController.GetOrders();

        ViewOrders(orders);

        Console.Write("\nSelect an order by its index to view the order details: ");
        var index = _userInput.GetId();

        Order order = new();
        try
        {
            index = orders[index - 1].Id;
            order = orders.FirstOrDefault(x => x.Id == index);
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine($"Order with the index '{index}' does not exist. Press any key to try again...");
            Console.ReadLine();
            ViewOrderDetails();
        }

        var orderDetails = $"[Orange3]Id: #{index}[/]  [Gold3]Date: {order.OrderDate}[/]\n";
        orderDetails += $@"[Mediumpurple2]Orders
---------------[/]";
        foreach (var item in order.OrderProducts)
        {
            orderDetails += string.Format("\n[mediumorchid1]{0} - ${1}\n[/] ",item.Product.Name.PadRight(15),item.Product.Price);
        }
        orderDetails += string.Format("\n[aquamarine1_1]{0}{1:c}[/]", "Total price:".PadRight(18), order.TotalPrice);
        var panel = new Panel(orderDetails);
        panel.Header=new PanelHeader("[Green]Order Details[/]");
        panel.Border = BoxBorder.Rounded;
        panel.Padding=new Padding(2,2,2,2);
        AnsiConsole.Write(panel);
      
        Console.Write("Do you want to view another orders, order details? yes/no: ");
        string answer = _userInput.GetValidAnswer();

        if (answer == "y" || answer == "yes")
        {
            ViewOrderDetails();
        }
    }

    private ProductDto MapProductToProductDto(Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };
    }

    private List<ProductDto> MapProductListToProductDtoList(List<Product> productList)
    {
        var productDtoList = new List<ProductDto>();

        foreach (var product in productList)
        {
            productDtoList.Add(MapProductToProductDto(product));
        }

        return productDtoList;
    }
}
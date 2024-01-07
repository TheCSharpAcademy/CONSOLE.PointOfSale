using KebPOS.Models;
using KebPOS.Models.Dtos;
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
    MainMenuSelections.DeleteOrder,
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
                case MainMenuSelections.DeleteOrder:
                    DeleteOrder();
                    break;
            }
        }
    }

    private void DeleteOrder()  // Buray� kodluyorsun
    {
        ViewOrders(_kebabController.GetOrders());
        bool validId = false;
        var allOrders = _kebabController.GetOrders();
        int selectedOrderId = 0;

        do
        {
            selectedOrderId = AnsiConsole.Ask<int>("Enter the Id of order to be deleted.");
            validId = Validation.IsValidOrderId(selectedOrderId, allOrders);
            if (!validId)
                Console.WriteLine("Please enter a valid Id");

        } while (!validId);

        var areYouSure = AnsiConsole.Confirm($"[Red] This will delete the order[/] [yellow]#{selectedOrderId}[/][red] Are you SURE?[/]", false);
        if (!areYouSure)
        {
            Console.Clear();
            return;
        }

        var toBeDeleted = allOrders[selectedOrderId - 1];
        _kebabController.RemoveOrder(toBeDeleted);
    }
    private void AddNewOrder()
    {
        Dictionary<int, int> productQuantityPairs = new();

        decimal totalPrice = 0;

        string answer;
        do
        {
            var products = _kebabController.GetProducts();

            var productDtoList = MapProductListToProductDtoList(products);

            _userInterface.DisplayProducts(productDtoList);

            var id = GetSelectedProduct(products);
            var quantity = GetProductQuantity();

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

            Console.Write("Do you want to add another product to your order? yes/no: ");
            answer = _userInput.GetValidAnswer();
        } while (answer != "n" && answer != "no");

        var order = CreateNewOrder(totalPrice);

        var orderProductsList = GetOrderProductList(productQuantityPairs, order);

        _kebabController.AddOrders(orderProductsList);
    }

    private int GetProductQuantity()
    {
        Console.Write("How many do you want to add to your order?: ");
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
        Console.Write("Select a product by Id to add to cart: ");
        var choice = _userInput.GetId();

        var id = int.Parse(choice);

        while (!products.Exists(p => p.Id == id))
        {
            Console.Write("Select a product by Id to add to cart: ");
            choice = _userInput.GetId();

            id = int.Parse(choice);
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
        var indexString = _userInput.GetId();
        int index = int.Parse(indexString);

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

        _userInterface.DisplayOrderDetails(order);

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
using KebPOS.Models;
using KebPOS.Models.Dtos;
using KebPOS.Services;
using Spectre.Console;
using static KebPOS.Models.Enums;

namespace KebPOS;

public class UserInterface
{
    private readonly KebabController _kebabController = new();
    private readonly UserInput _userInput = new();

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
    MainMenuSelections.ManageProducts,
    MainMenuSelections.ViewReports,
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
                case MainMenuSelections.ManageProducts:
                    ManageProductsMenu();
                    break;
                case MainMenuSelections.ViewReports:
                    ManageReportsMenu();
                    break;
            }
        }
    }

    internal void ManageProductsMenu()
    {
        var selection = AnsiConsole.Prompt(
        new SelectionPrompt<ManageProductsSelections>()
       .Title("[Purple] Manage Products Menu[/]\nWhat would you like to do?")
       .PageSize(10)
       .MoreChoicesText("")
       .AddChoices(ManageProductsSelections.ViewProducts,
       ManageProductsSelections.ViewProductDetails,
       ManageProductsSelections.AddProduct,
       ManageProductsSelections.UpdateProduct,
       ManageProductsSelections.DeleteProduct,
       ManageProductsSelections.ReturnToMainMenu));

        switch (selection)
        {
            case ManageProductsSelections.ViewProducts:
                //add method
                break;
            case ManageProductsSelections.ViewProductDetails:
                //add method
                break;
            case ManageProductsSelections.AddProduct:
                //add method
                break;
            case ManageProductsSelections.UpdateProduct:
                UpdateProduct();
                break;
            case ManageProductsSelections.DeleteProduct:
                //add method
                break;
            case ManageProductsSelections.ReturnToMainMenu:
                InitializeMenu();
                break;
        }

    }

    internal void ManageReportsMenu()
    {
        var selection = AnsiConsole.Prompt(
        new SelectionPrompt<ViewReportsSelections>()
        .Title("[Purple] Manage Reports Menu[/]\nWhich time period do you want to view sales for?")
        .PageSize(5)
        .MoreChoicesText("")
        .AddChoices(ViewReportsSelections.SalesPerMonth,
        ViewReportsSelections.SalesPerYear,
        ViewReportsSelections.SalesPerDay,
        ViewReportsSelections.SalesPerWeek,
        ViewReportsSelections.ReturnToMainMenu));

        switch (selection)
        {
            case ViewReportsSelections.SalesPerMonth:
                ReportsService.GetSalesPerMonth();
                break;
            case ViewReportsSelections.SalesPerYear:
                ReportsService.GetSalesPerYear();
                break;
            case ViewReportsSelections.SalesPerDay:
                ReportsService.GetSalesPerDay();
                break;
            case ViewReportsSelections.SalesPerWeek:
                ReportsService.GetSalesPerWeek();
                break;
            case ViewReportsSelections.ReturnToMainMenu:
                InitializeMenu();
                break;
        }
    }

    private void UpdateProduct()
    {
        var products = _kebabController.GetProducts();
        var productsNameList=products.Select(x => x.Name).ToList();
        var selectedProductName = AnsiConsole.Prompt(new SelectionPrompt<string>().
                                    Title("[Purple]Select product[/]").
                                    AddChoices(productsNameList));
        Product productToUpdate=products.Single(x=> x.Name==selectedProductName);
        var propertyToUpdate = AnsiConsole.Prompt(new SelectionPrompt<ProductProperties>()
            .Title("[Purple]Select property to update[/]")            
            .AddChoices(
                            ProductProperties.Name,
                            ProductProperties.Description,
                            ProductProperties.Price,
                            ProductProperties.MainMenu));

        switch(propertyToUpdate)
        {
            case ProductProperties.Name:
                UpdateProductName(productToUpdate);
                break;
            case ProductProperties.Description:
                UpdateProductDescription(productToUpdate);
                break;
            case ProductProperties.Price:
                UpdateProductPrice(productToUpdate);
                break;
            case ProductProperties.MainMenu:
                break;
        }
    }

    private void UpdateProductName(Product productToUpdate)
    {
        AnsiConsole.Markup($"[Blue]Current name:[/] {productToUpdate.Name}\n\n");
        string newName = AnsiConsole.Ask<string>("[Yellow]Enter new name:[/] ");
        _kebabController.UpdateProductName(productToUpdate, newName);
    }

    private void UpdateProductDescription(Product productToUpdate)
    {
        AnsiConsole.Markup($"[Blue]Current description:[/] {productToUpdate.Description}\n\n");
        string newDescription = AnsiConsole.Ask<string>("[Yellow]Enter new description:[/] ");
        _kebabController.UpdateProductDescription(productToUpdate, newDescription);
    }

    private void UpdateProductPrice(Product productToUpdate)
    {
        AnsiConsole.Markup($"[Blue]Current price:[/] {productToUpdate.Price}");
        decimal newPrice = AnsiConsole.Ask<decimal>("[Yellow]Enter new price:[/] ");
        _kebabController.UpdateProductPrice(productToUpdate, newPrice);
    }
    private void DeleteOrder()  // Burayý kodluyorsun
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

            DisplayProducts(productDtoList);

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
        DisplayOrders(orders);
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

        DisplayOrderDetails(order);

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

    public void DisplayProducts(List<ProductDto> products)
    {
        var productTable = new Table().Centered();

        var blue = "blue";
        var yellow = "yellow";
        var red = "red";

        productTable.AddColumns(
            new TableColumn($"[{blue}]Id[/]"),
            new TableColumn($"[{blue}]Name[/]"),
            new TableColumn($"[{blue}]Price[/]")
        );

        foreach (var product in products)
        {
            productTable.AddRow(new List<Markup>
            {
                new (product.Id.ToString()),
                new ($"[{yellow}]{product.Name}[/]"),
                new ($"[{red}]{product.Price}[/]")
            });

            productTable.AddEmptyRow();
            productTable.AddEmptyRow();
        }

        AnsiConsole.Write(productTable);
    }

    public void DisplayOrders(List<Order> orders)
    {
        var orderTable = new Table().Centered();

        var blue = "blue";
        var yellow = "yellow";
        var red = "red";

        orderTable.AddColumns(
            new TableColumn($"[{blue}]Id[/]"),
            new TableColumn($"[{blue}]Order Date[/]"),
            new TableColumn($"[{blue}]Total Price[/]")
        );

        foreach (var order in orders)
        {
            orderTable.AddRow(new List<Markup>
            {
                new ($"#{orders.IndexOf(order) + 1}"),
                new ($"[{yellow}]{order.OrderDate}[/]"),
                new ($"[{red}]{order.TotalPrice}[/]")
            });

            orderTable.AddEmptyRow();
            orderTable.AddEmptyRow();
        }

        AnsiConsole.Write(orderTable);
    }

    public void DisplayOrderDetails(Order order)
    {
        var orderDetails = $"[Orange3]Id: #{order.Id}[/]  [Gold3]Date: {order.OrderDate}[/]\n";
        orderDetails += $@"[Mediumpurple2]Orders
---------------[/]";
        foreach (var item in order.OrderProducts)
        {
            orderDetails += string.Format("\n[mediumorchid1]{0}x - {1} - ${2}\n[/] ", item.Quantity, item.Product.Name.PadRight(15), item.Product.Price);
        }
        orderDetails += string.Format("\n[aquamarine1_1]{0}{1:c}[/]", "Total price:".PadRight(18), order.TotalPrice);
        var panel = new Panel(orderDetails);
        panel.Header = new PanelHeader("[Green]Order Details[/]");
        panel.Border = BoxBorder.Rounded;
        panel.Padding = new Padding(2, 2, 2, 2);
        AnsiConsole.Write(panel);
    }
}

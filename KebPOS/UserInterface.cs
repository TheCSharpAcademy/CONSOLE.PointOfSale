using KebPOS.Models;
using KebPOS.Models.Dtos;
using Spectre.Console;

namespace KebPOS;

public class UserInterface
{
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

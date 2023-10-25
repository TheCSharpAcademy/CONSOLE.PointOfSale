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
}

using KebPOS.Models;
using Spectre.Console;

namespace KebPOS;

public class UserInterface
{
    public void DisplayProducts(List<Product> products)
    {
        var productTable = new Table().Centered();

        var blue = "blue";
        var yellow = "yellow";
        var red = "red";

        productTable.AddColumns(
            new TableColumn($"[{blue}]Id[/]"),
            new TableColumn($"[{blue}]Name[/]"),
            new TableColumn($"[{blue}]Price[/]"),
            new TableColumn($"[{blue}]Description[/]")
        );

        var tabSpace = "    ";

        foreach (var product in products)
        {
            productTable.AddRow(new List<Markup>
            {
                new (product.Id.ToString()),
                new ($"[{yellow}]{product.Name}[/]"),
                new ($"[{red}]{product.Price.ToString()}[/]"),
                new (product.Description.Replace(tabSpace, ""))
            });

            productTable.AddEmptyRow();
            productTable.AddEmptyRow();
        }

        AnsiConsole.Write(productTable);
    }
}

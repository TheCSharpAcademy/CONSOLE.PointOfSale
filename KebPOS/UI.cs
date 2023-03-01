using KebPOS.Models;
using Spectre.Console;
using System.Text.RegularExpressions;

namespace KebPOS
{
    internal static class UI
    {
        internal static void DisplayProducts(List<Product> products)
        {

            products = products.OrderBy(p => p.Id).ToList();

            var skeletonGrid = new Grid();
            skeletonGrid.AddColumn();

            AnsiConsole.WriteLine();
            foreach (var product in products)
            {
                var rowGrid = new Grid();
                rowGrid.AddColumn();

                // Id, Name and Price
                var productTopGrid = new Grid();
                productTopGrid.AddColumns(3);
                productTopGrid.AddRow(new Markup[] 
                { 
                    new Markup($"[bold blue]Id[/][grey]:[/] [silver]{product.Id}[/]    "), 
                  new Markup($"[bold blue]Name[/][grey]:[/] [silver]{product.Name}[/]    "), 
                    new Markup($"[bold blue]Price[/][grey]:[/] [silver]{product.Price}[/]"),
                });

                // Description
                var productBottomGrid = new Grid();
                productBottomGrid.AddColumn();
                productBottomGrid.AddRow(new Markup(
                    $"[bold blue]Description[/][grey]:[/]\n[silver]{RemoveTabsFromString(product.Description)}[/]"));

                // Join top and bottom
                rowGrid.AddRow(productTopGrid);
                rowGrid.AddRow(productBottomGrid);
                rowGrid.AddEmptyRow();

                skeletonGrid.AddRow(rowGrid);
            }

            AnsiConsole.Write(skeletonGrid);
        }

        private static string RemoveTabsFromString(string text)
        {
            const string reduceMultiSpace = @"[ ]{2,}";
            var output = Regex.Replace(text.Replace("\t", " "), reduceMultiSpace, " ");
            return output;
        }
    }
}

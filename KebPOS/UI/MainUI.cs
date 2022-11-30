using KebPOS.Models;
using Spectre.Console;
using SpectreTable = Spectre.Console.Table;
using Spectre.Console.Extensions.Table;
using System.Data;

namespace KebPOS.UI
{
    public class MainUI
    {
        public void DisplayProductsTable(List<Product> products)
        {
            var table = new Table();
            table.AddColumn("Id"); 
            table.AddColumn("Name"); 
            table.AddColumn("Description"); 
            table.AddColumn("Price"); 
            table.Border(TableBorder.Rounded);
            table.Centered();
            table.Expand();
            foreach (var p in products)
            {
                table.AddRow($"{p.Id}", $"{p.Name}", $"{p.Description}", $"{p.Price}");   
            }

            // var tableToDisplay = table.FromDataTable().Border(TableBorder.Rounded); 
            AnsiConsole.Write(table); 
        }
    }
}
using KebPOS.Models;
using Spectre.Console;
using SpectreTable = Spectre.Console.Table;
using Spectre.Console.Extensions.Table;
using System.Data;

namespace KebPOS.UI
{
    public class MainUI
    {
        public MainUI()
        {

        }

        public void DisplayProductsTable(List<Product> products)
        {
            var ansitable = new Table(); 
            ansitable.Columns.Add(); 
            var table = GenerateTable();
            foreach (var row in products.Select(p => ToDataRow(p, table)))
            {
                table.Rows.Add(row);
                
                 
            }
            

            var tableToDisplay = table.FromDataTable().Border(TableBorder.Rounded); 
            AnsiConsole.Write(tableToDisplay); 
        }


        private static DataTable GenerateTable()
        {
            DataTable dt = new();
            dt.TableName = "Kebabs";
            _ = dt.Columns.Add(nameof(Product.Id), typeof(int));
            _ = dt.Columns.Add(nameof(Product.Name), typeof(string));
            _ = dt.Columns.Add(nameof(Product.Description), typeof(string));
            _ = dt.Columns.Add(nameof(Product.Price), typeof(decimal));

            return dt;
        }

        private static DataRow ToDataRow(Product p, DataTable dataTable)
        {
            DataRow row = dataTable.NewRow();
            row[nameof(Product.Id)] = p.Id;
            row[nameof(Product.Name)] = p.Name;
            row[nameof(Product.Description)] = p.Description;
            row[nameof(Product.Price)] = p.Price;
            return row;
        }
    }
}
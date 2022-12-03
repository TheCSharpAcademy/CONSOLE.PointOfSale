using KebPOS.Models;
using SpectreTable = Spectre.Console.Table;
using Spectre.Console.Extensions.Table;
using System.Data;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic.CompilerServices;
using Spectre.Console;

namespace KebPOS.UI
{
    public class MainUi
    {
        /// <summary>
        /// Display data table
        /// </summary>
        /// <param name="data">Data to display</param>
        public void DisplayTable<T>(List<T> data) where T : class, new()
        {
             var table = new SpectreTable();
             table.Title("Kebabs"); 

             var cols = data[0].GetType().GetProperties();
                
             //Generate columns based on property names
            foreach (PropertyInfo col in cols)
            {
                table.AddColumn(new TableColumn(col.Name).Centered());
            }

            //TODO: Add data rows to table Dynamically

             AnsiConsole.Write(table);
        }
    }
} 
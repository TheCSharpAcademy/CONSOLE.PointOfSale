using KebPOS.Models;
using Spectre.Console;
using SpectreTable = Spectre.Console.Table;
using Spectre.Console.Extensions.Table;
using System.Data;

namespace KebPOS.UI
{
    public class MainUI
    {
        public void DisplayTable(List<T> items) where T : class, new()
        {
             List<T> rows = new List<T>(); 
             T entry = new T(); 
             var cols = entry.GetType().GetProperties(); 
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KebPOS.Services
{
    internal class ProductService
    {
        public List<string> GetProducts()
        {
            var order = new List<string>();
            order.AddRange(new string[] {
                "Yogurt Kebab", "Shish Kebab", "Doner Kebab", "Kathi Kebab", "Chapli Kebab",
                "Burrah Kebab", "Beyti Kebab", "Adana Kebab", "Chicken Sis Kebab", "Turkish Sis Kebab",
                "Water", "Tea", "Milk", "Coffee", "Beer"
            });
            return order;
        }
    }
}

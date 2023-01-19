using KebPOS.Models;
using KebPOS.Services;

namespace KebPOS;

public class Validation
{
    public static bool IsValidIdInput(string input)
    {
        return int.TryParse(input, out int parsedInput) ? parsedInput > 0 : false;
    }

    internal static bool IsValidProductId(string? input)
    {
        List<Product> validProducts = ProductService.GetProducts();
        if (!Int32.TryParse(input, out int id))
        {
            return false;
        }
        else 
        {
            return validProducts.Any(x => x.Id == id);
        }
    }
}

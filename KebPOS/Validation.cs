
using KebPOS.Models;
using KebPOS.Services;

namespace KebPOS;
public class Validation
{
    public static bool IsValidIdInput(string input)
    {
        return int.TryParse(input, out int parsedInput) ? parsedInput > 0 : false;
    }

    public static bool IsValidAnswer(string? answer)
    {
        var answersArray = new string[4] { "y", "yes", "n", "no" };

        return !string.IsNullOrWhiteSpace(answer) && answersArray.Contains(answer);
    }

    public static bool IsValidOrderId(int id, IEnumerable<Models.Order> orders)
    {
        int maxId = orders.Count();
        if (id <= 0 || id > maxId)
            return false;
        else
            return true;
    }

    internal static bool CheckStringLength(string stringToCheck, int nameLengthLimit)
    {
        bool valid = false;
        if (stringToCheck.Length < nameLengthLimit)
        { valid = true; }
        return valid;
    }

    internal static bool CheckDuplicateProductName(Product product)
    {
        bool isDuplicate = true;
        List<Product> dbproducts = ProductService.GetProductsFromDatabase();

        isDuplicate = dbproducts.Any(p => String.Equals(p.Name, product.Name, StringComparison.OrdinalIgnoreCase));
        return isDuplicate;

    }

    // User might have a loss leader or sale item you want to ring up for zero
    // but want to track.  ie: water cups
    // -- So I make sure it just can't be negative 
    internal static bool CheckPrice(decimal price)
    {
        bool valid = price >= 0;
        return valid;
    }
}

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
}

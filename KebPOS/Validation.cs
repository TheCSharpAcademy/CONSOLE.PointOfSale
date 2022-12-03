namespace KebPOS;

public class Validation
{
    public static bool IsValidIdInput(string input)
    {
        return int.TryParse(input, out int parsedInput) ? parsedInput > 0 : false;
    }
}

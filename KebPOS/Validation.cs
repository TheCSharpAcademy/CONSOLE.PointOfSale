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
}

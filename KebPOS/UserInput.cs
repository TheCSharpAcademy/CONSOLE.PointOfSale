namespace KebPOS;

public class UserInput
{
    public int GetId()
    {
        var id = Console.ReadLine();
        while (!Validation.IsValidIdInput(id))
        {
            id = Console.ReadLine();
        }

        return int.Parse(id);
    }

    public string GetValidAnswer()
    {
        var answer = Console.ReadLine();
        while (!Validation.IsValidAnswer(answer))
        {
            answer = Console.ReadLine();
        }

        return answer;
    }

    public int GetQuantity()
    {
        var input = Console.ReadLine();
        while (!Validation.IsValidIdInput(input))
        {
            input = Console.ReadLine();
        }

        return int.Parse(input);
    }
}
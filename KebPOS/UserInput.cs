namespace KebPOS;

public class UserInput
{
    public int GetId()
    {
        var id = Console.ReadLine();
        if (id == "back")
        {
            return -1;
        }

        while (!Validation.IsValidIdInput(id))
        {
            id = Console.ReadLine();
            if (id == "back")
            {
                return -1;
            }
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
        if (input == "back")
        {
            return -1;
        }

        while (!Validation.IsValidIdInput(input))
        {
            input = Console.ReadLine();
            if (input == "back")
            {
                return -1;
            }
        }

        return int.Parse(input);
    }
}
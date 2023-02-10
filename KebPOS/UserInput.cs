namespace KebPOS;

public class UserInput
{
    public string GetId()
    {
        var id = Console.ReadLine();
        while (!Validation.IsValidIdInput(id))
        {
            id = Console.ReadLine();
        }

        return id;
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
}
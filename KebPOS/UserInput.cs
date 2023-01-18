using KebPOS.Models;

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
}
// See https://aka.ms/new-console-template for more information


public static class UserInterface
{
    public static string ReadInput()
    {
        string? userInput;
        do
        {
            userInput = Console.ReadLine();
            userInput = userInput.Trim();
        } while (string.IsNullOrEmpty(userInput));
        return userInput!;
    }

    public static void PrintMessage(string Message)
    {
        Console.WriteLine(Message);
    }

    public static string SelectColumn(List<string> columns)
    {
        PrintMessage("");
        PrintMessage("Please select a column to find min/ max values");
        PrintMessage($"Select from: {string.Join(", ", columns)}");
        PrintMessage("Type exit to quit/exit the program");
        return ReadInput();
    }
}

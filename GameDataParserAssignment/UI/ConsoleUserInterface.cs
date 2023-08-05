public class ConsoleUserInterface : IUserInterfaceLogger
{
    IFileHandler<string> Logger;
    public ConsoleUserInterface(IFileHandler<string> _logger)
    {
        Logger = _logger;
    }
    public void Message(string msg, string stackTrace, int level)
    {
        switch (level)
        {
            case 0:
                Console.ResetColor();
                break;
            case 1:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
        }

        if (stackTrace != "")
        {
            Logger.Write("log.txt", $"Exception message: {msg}{Environment.NewLine}Stack trace: {stackTrace}");
        }

        Console.WriteLine(msg);
        Console.ResetColor();
    }

    public void ShowGames(List<Game> listOfGames)
    {
        Console.WriteLine("Loaded games are:");
        foreach (var game in listOfGames)
        {
            Console.WriteLine($"{game.Title}, released in {game.ReleaseYear}, rating: {game.Rating}");
        }
    }


}

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
            case 2:
                Console.ForegroundColor = ConsoleColor.DarkYellow;
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
        if (listOfGames is not null && listOfGames.Count > 0)
        {
            Console.WriteLine("Loaded games are:");
            foreach (var game in listOfGames)
            {
                Console.WriteLine(game);
            }
        }
        else if (listOfGames is null)
        {
            return;
        }
        else
        {
            Console.WriteLine("No games are present in the input file.");
        }
    }


}

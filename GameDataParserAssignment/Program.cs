
using GameDataParserAssignment.FileHandling;

// initialize the handlers
IFileHandler<string> LoggingFileHandler = new LoggerFileHandling();
IUserInterfaceLogger ConsoleUI = new ConsoleUserInterface(LoggingFileHandler);
IFileHandler<List<Game>> JsonFileHandler = new JsonFileHandler(ConsoleUI);
IUserInputHandler UserInput = new ConsoleInput(ConsoleUI);

// initialize a game instance with the handlers to be injected
GameDataParser gameDataParser = new(JsonFileHandler, ConsoleUI, UserInput);

try
{
    // call main procedure
    gameDataParser.run();
}
catch (Exception ex)
{
    ConsoleUI.Message($"Sorry! The application has experienced an unexpected error and will have to be closed.{Environment.NewLine}Error message: {ex.Message}", ex.StackTrace, 1);
}
finally
{
    Console.ReadKey();
}